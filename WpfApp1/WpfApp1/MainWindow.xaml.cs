using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Apis.Auth.OAuth2;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token = "d9gUEmE_Tt2Y24QeRAT4QA:APA91bERXuM6IH-a_NLRa6Vb52KzKnMxCuy1nbvppEtTJytkRWz3_TXx_y_WxXiXyyIEf6YPn-Q8JvvVJjsQt9U8XjOjGGbr741PSSs79_Y4-VMk-4J8WJc1dCsZf3VXaKZqpb76k5Tl";
        private FirebaseApp firebaseApp = null;
        private FirebaseMessaging firebaseMessaging = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await SendFCMMessage(token, "전달할 제목", "전달할 내용 입니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void init()
        {
            firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("E:\\FirebaseAdmin_test\\winfrmFCM\\serviceAccountKey.json"),
            });
            firebaseMessaging = FirebaseMessaging.GetMessaging(firebaseApp);
        }

        private Task SendFCMMessage(string sToken, string sTitle, string sMsg)
        {
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

            return firebaseMessaging.SendAsync(message);
        }

    }
}
