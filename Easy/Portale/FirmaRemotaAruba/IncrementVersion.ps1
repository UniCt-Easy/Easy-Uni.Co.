param (
    [string]$AssemblyInfoFile
)

Write-Host "Eseguendo IncrementVersion.ps1"
Write-Host "File AssemblyInfo: $AssemblyInfoFile"

# Controlla se il file esiste
if (-Not (Test-Path $AssemblyInfoFile)) {
    Write-Error "Il file $AssemblyInfoFile non esiste!"
    exit 1
}

# Leggi il contenuto di AssemblyInfo.cs come array di righe
$content = Get-Content -Path $AssemblyInfoFile

# Trova la riga con AssemblyFileVersion e incrementa la build
$pattern = '\[assembly: AssemblyFileVersion\("(\d+)\.(\d+)\.(\d+)\.(\d+)"\)\]'
$updated = $false

for ($i = 0; $i -lt $content.Length; $i++) {
    if ($content[$i] -match $pattern) {
        # Debug: Mostra la riga trovata
        Write-Host "Trovata riga: $content[$i]"

        # Estrai i numeri di versione
        $major = [int]$Matches[1]
        $minor = [int]$Matches[2]
        $build = [int]$Matches[3] + 1 # Incrementa la build
        $revision = [int]$Matches[4]

        # Crea la nuova riga
        $newVersion = "[assembly: AssemblyFileVersion(`"$major.$minor.$build.$revision`")]"

        # Sostituisci la riga
        $content[$i] = $newVersion
        $updated = $true

        Write-Host "Trovata e aggiornata versione: $newVersion"
        break
    }
}

if (-Not $updated) {
    Write-Error "Non è stato trovato AssemblyFileVersion nel file!"
    exit 1
}

# Salva il contenuto aggiornato
Set-Content -Path $AssemblyInfoFile -Value $content
Write-Host "File aggiornato correttamente!"
