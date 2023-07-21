using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace WhatsAppSenderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SendWhatsAppMessage(string toPhoneNumber, string message)
        {
            // Replace these with your Twilio Account SID and Auth Token
            const string accountSid = "XXXXXXXXXXXX";
            const string authToken = "XXXXXXXXXXXX";

            TwilioClient.Init(accountSid, authToken);

            // Replace this with your Twilio WhatsApp number (with the country code)
            const string twilioWhatsAppNumber = "XXXXXXXXXXXXXXXXXXX";

            var messageResource = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber($"whatsapp:{twilioWhatsAppNumber}"),
                to: new Twilio.Types.PhoneNumber($"whatsapp:{"xxxxxxxxxxxxx"}")
            );

            // Check if the message was successfully sent
            if (messageResource.Status == MessageResource.StatusEnum.Sent)
            {
                MessageBox.Show("WhatsApp message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error sending WhatsApp message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string phoneNumber = textBox1.Text.Trim();
            string message = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(phoneNumber) && !string.IsNullOrEmpty(message))
            {
                SendWhatsAppMessage(phoneNumber, message);
            }
            else
            {
                MessageBox.Show("Please enter both a phone number and a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
