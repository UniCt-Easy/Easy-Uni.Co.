/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordValidation
{
    /// <summary>
    /// Specifies options for password requirements.
    /// </summary>
    public class PasswordOptions
    {
        /// <summary>
        /// Gets or sets the minimum length a password must be. Defaults to 6.
        /// </summary>
        public int RequiredLength { get; set; } = 6;

        /// <summary>
        /// Gets or sets the minimum number of unique chars a password must comprised of. Defaults to 1.
        /// </summary>
        public int RequiredUniqueChars { get; set; } = 1;

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a non-alphanumeric character. Defaults to true.
        /// </summary>
        /// <value>True if passwords must contain a non-alphanumeric character, otherwise false.</value>
        public bool RequireNonAlphanumeric { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a lower case ASCII character. Defaults to true.
        /// </summary>
        /// <value>True if passwords must contain a lower case ASCII character.</value>
        public bool RequireLowercase { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a upper case ASCII character. Defaults to true.
        /// </summary>
        /// <value>True if passwords must contain a upper case ASCII character.</value>
        public bool RequireUppercase { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating if passwords must contain a digit. Defaults to true.
        /// </summary>
        /// <value>True if passwords must contain a digit.</value>
        public bool RequireDigit { get; set; } = true;
    }

    /// <summary>
    /// Encapsulates an error from the identity subsystem.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description for this error.
        /// </summary>
        /// <value>
        /// The description for this error.
        /// </value>
        public string Description { get; set; }
    }

    public class ValidationResult
    {
        private static readonly ValidationResult _success = new ValidationResult { Succeeded = true };
        private List<ValidationError> _errors = new List<ValidationError>();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/>s containing an errors
        /// that occurred during the identity operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/>s.</value>
        public IEnumerable<ValidationError> Errors => _errors;

        /// <summary>
        /// Returns an <see cref="ValidationResult"/> indicating a successful identity operation.
        /// </summary>
        /// <returns>An <see cref="ValidationResult"/> indicating a successful operation.</returns>
        public static ValidationResult Success => _success;

        /// <summary>
        /// Creates an <see cref="ValidationResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="ValidationError"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="ValidationResult"/> indicating a failed identity operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static ValidationResult Failed(params ValidationError[] errors)
        {
            var result = new ValidationResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }

        /// <summary>
        /// Converts the value of the current <see cref="ValidationResult"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current <see cref="ValidationResult"/> object.</returns>
        /// <remarks>
        /// If the operation was successful the ToString() will return "Succeeded" otherwise it returned 
        /// "Failed : " followed by a comma delimited list of error codes from its <see cref="Errors"/> collection, if any.
        /// </remarks>
        public override string ToString()
        {
            return Succeeded ?
                   "Succeeded" :
                   string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }

    public class PasswordValidator
    {
        /// <summary>
        /// Gets the <see cref="PasswordOptions"/> used to validate the password.
        /// </summary>
        /// <value>The <see cref="PasswordOptions"/> used to validate the password.</value>
        public PasswordOptions options { get; private set; }

        /// <summary>
        /// Gets the <see cref="ValidationErrorDescriber"/> used to supply error text.
        /// </summary>
        /// <value>The <see cref="ValidationErrorDescriber"/> used to supply error text.</value>
        public ValidationErrorDescriber Describer { get; private set; }

        /// <summary>
        /// Constructions a new instance of <see cref="PasswordValidator"/>.
        /// </summary>
        /// <param name="errors">The <see cref="ValidationErrorDescriber"/> to retrieve error text from.</param>
        public PasswordValidator(PasswordOptions opts = null, ValidationErrorDescriber errors = null)
        {
            options = opts ?? new PasswordOptions();
            Describer = errors ?? new ValidationErrorDescriber();
        }


        public ValidationResult Validate(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var errors = new List<ValidationError>();

            if (string.IsNullOrWhiteSpace(password) || password.Length < options.RequiredLength)
            {
                errors.Add(Describer.PasswordTooShort(options.RequiredLength));
            }
            if (options.RequireNonAlphanumeric && password.All(IsLetterOrDigit))
            {
                errors.Add(Describer.PasswordRequiresNonAlphanumeric());
            }
            if (options.RequireDigit && !password.Any(IsDigit))
            {
                errors.Add(Describer.PasswordRequiresDigit());
            }
            if (options.RequireLowercase && !password.Any(IsLower))
            {
                errors.Add(Describer.PasswordRequiresLower());
            }
            if (options.RequireUppercase && !password.Any(IsUpper))
            {
                errors.Add(Describer.PasswordRequiresUpper());
            }
            if (options.RequiredUniqueChars >= 1 && password.Distinct().Count() < options.RequiredUniqueChars)
            {
                errors.Add(Describer.PasswordRequiresUniqueChars(options.RequiredUniqueChars));
            }

            return errors.Count == 0 ? ValidationResult.Success : ValidationResult.Failed(errors.ToArray());
        }

        /// <summary>
        /// Returns a flag indicating whether the supplied character is a digit.
        /// </summary>
        /// <param name="c">The character to check if it is a digit.</param>
        /// <returns>True if the character is a digit, otherwise false.</returns>
        public bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// Returns a flag indicating whether the supplied character is a lower case ASCII letter.
        /// </summary>
        /// <param name="c">The character to check if it is a lower case ASCII letter.</param>
        /// <returns>True if the character is a lower case ASCII letter, otherwise false.</returns>
        public bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        /// <summary>
        /// Returns a flag indicating whether the supplied character is an upper case ASCII letter.
        /// </summary>
        /// <param name="c">The character to check if it is an upper case ASCII letter.</param>
        /// <returns>True if the character is an upper case ASCII letter, otherwise false.</returns>
        public bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        /// <summary>
        /// Returns a flag indicating whether the supplied character is an ASCII letter or digit.
        /// </summary>
        /// <param name="c">The character to check if it is an ASCII letter or digit.</param>
        /// <returns>True if the character is an ASCII letter or digit, otherwise false.</returns>
        public bool IsLetterOrDigit(char c)
        {
            return IsUpper(c) || IsLower(c) || IsDigit(c);
        }
    }

        public class ValidationErrorDescriber
        {
            /// <summary>
            /// Returns the default <see cref="ValidationError"/>.
            /// </summary>
            /// <returns>The default <see cref="ValidationError"/>.</returns>
            public virtual ValidationError DefaultError()
            {
                return new ValidationError
                {
                    Code = nameof(DefaultError),
                    Description = "Errore imprevisto"
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.
            /// </summary>
            /// <param name="length">The length that is not long enough.</param>
            /// <returns>An <see cref="ValidationError"/> indicating a password of the specified <paramref name="length"/> does not meet the minimum length requirements.</returns>
            public virtual ValidationError PasswordTooShort(int length)
            {
                return new ValidationError
                {
                    Code = nameof(PasswordTooShort),
                    Description = string.Format("La password deve essere di almeno {0} caratteri", length)
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.
            /// </summary>
            /// <param name="uniqueChars">The number of different chars that must be used.</param>
            /// <returns>An <see cref="ValidationError"/> indicating a password does not meet the minimum number <paramref name="uniqueChars"/> of unique chars.</returns>
            public virtual ValidationError PasswordRequiresUniqueChars(int uniqueChars)
            {
                return new ValidationError
                {
                    Code = nameof(PasswordRequiresUniqueChars),
                    Description = string.Format("La password deve contenere almeno {0} caratteri unici", uniqueChars)
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password entered does not contain a non-alphanumeric character, which is required by the password policy.
            /// </summary>
            /// <returns>An <see cref="ValidationError"/> indicating a password entered does not contain a non-alphanumeric character.</returns>
            public virtual ValidationError PasswordRequiresNonAlphanumeric()
            {
                return new ValidationError
                {
                    Code = nameof(PasswordRequiresNonAlphanumeric),
                    Description = "La password deve contenere almeno un carattere non alfanumerico"
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password entered does not contain a numeric character, which is required by the password policy.
            /// </summary>
            /// <returns>An <see cref="ValidationError"/> indicating a password entered does not contain a numeric character.</returns>
            public virtual ValidationError PasswordRequiresDigit()
            {
                return new ValidationError
                {
                    Code = nameof(PasswordRequiresDigit),
                    Description = "La password deve contenere almeno una cifra"
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password entered does not contain a lower case letter, which is required by the password policy.
            /// </summary>
            /// <returns>An <see cref="ValidationError"/> indicating a password entered does not contain a lower case letter.</returns>
            public virtual ValidationError PasswordRequiresLower()
            {
                return new ValidationError
                {
                    Code = nameof(PasswordRequiresLower),
                    Description = "La password deve contenere almeno un carattere minuscolo"
                };
            }

            /// <summary>
            /// Returns an <see cref="ValidationError"/> indicating a password entered does not contain an upper case letter, which is required by the password policy.
            /// </summary>
            /// <returns>An <see cref="ValidationError"/> indicating a password entered does not contain an upper case letter.</returns>
            public virtual ValidationError PasswordRequiresUpper()
            {
                return new ValidationError
                {
                    Code = nameof(PasswordRequiresUpper),
                    Description = "La password deve contenere almeno un carattere maiuscolo"
                };
            }
        }
}
