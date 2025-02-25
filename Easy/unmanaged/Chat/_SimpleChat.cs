
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;

using RestSharp;

namespace QAClient {
    public partial class SimpleChat : Form {

        private readonly RestClient QA = new RestClient("http://10.10.10.183");

        private string lastQuestion = string.Empty;
        private string lastAnswer = string.Empty;

        public SimpleChat() {
            InitializeComponent();

            AcceptButton = btnGetAnswer;
            QA.AddDefaultHeader("psk", "token");
        }

        private void btnSend_Click(object sender, EventArgs e) {

            lastQuestion = txtQuestion.Text;

            var request = new RestRequest("answer", Method.POST) {
                AlwaysMultipartFormData = true,
            };

            request.AddParameter("question", txtQuestion.Text, ParameterType.RequestBody);
            request.AddFileBytes(string.Empty, new byte[] { }, string.Empty); // dobbiamo aggiungere un file vuoto a causa di un bug di RestSharp v105.2.3.0 (https://github.com/restsharp/RestSharp/issues/1134)

            var response = QA.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {

                txtAnswer.Text = response.Content.ToString();
                lastAnswer = txtAnswer.Text;

                BringToFront();
            }

            //lstHistory.Items.Add(new object() { Question = lastQuestion, Answer = lastAnswer });
            txtQuestion.Clear();
        }

        private void btnGood_Click(object sender, EventArgs e) {

        }

        private void btnBad_Click(object sender, EventArgs e) {

        }
    }
}