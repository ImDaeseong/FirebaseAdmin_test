using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using System.Net;
using System.Runtime.Remoting.Messaging;

namespace winfrmFCM
{
    public partial class Form1 : Form
    {

        private string token = "d9gUEmE_Tt2Y24QeRAT4QA:APA91bERXuM6IH-a_NLRa6Vb52KzKnMxCuy1nbvppEtTJytkRWz3_TXx_y_WxXiXyyIEf6YPn-Q8JvvVJjsQt9U8XjOjGGbr741PSSs79_Y4-VMk-4J8WJc1dCsZf3VXaKZqpb76k5Tl";

        private FirebaseApp FirebaseApp = null;
        private FirebaseMessaging firebaseMessaging = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await sendFCMMessage(token, "전달할 제목", "전달할 내용 입니다");
        }

        private void init()
        {
            FirebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("E:\\FirebaseAdmin_test\\winfrmFCM\\serviceAccountKey.json"),
            });
            firebaseMessaging = FirebaseMessaging.GetMessaging(FirebaseApp);
        }

        private Task sendFCMMessage(string sToken, string sTitle, string sMsg)
        {
            var client_token = sToken;
            var messageData = new Dictionary<string, string>()
            {
                { "title", sTitle },
                { "message", sMsg }
            };

            var message = new FirebaseAdmin.Messaging.Message()
            {
                Data = messageData,
                Token = sToken
            };

            return FirebaseMessaging.DefaultInstance.SendAsync(message);
        }

    }
}
