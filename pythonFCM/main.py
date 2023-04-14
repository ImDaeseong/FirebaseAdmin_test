import firebase_admin
from firebase_admin import credentials
from firebase_admin import messaging

android_token = "d9gUEmE_Tt2Y24QeRAT4QA:APA91bERXuM6IH-a_NLRa6Vb52KzKnMxCuy1nbvppEtTJytkRWz3_TXx_y_WxXiXyyIEf6YPn-Q8JvvVJjsQt9U8XjOjGGbr741PSSs79_Y4-VMk-4J8WJc1dCsZf3VXaKZqpb76k5Tl"


def init():
    cred = credentials.Certificate("serviceAccountKey.json")
    firebase_admin.initialize_app(cred)


def sendFCMMessage():
    message = messaging.Message(
        notification=messaging.Notification(
            title='전달할 제목',
            body='전달할 내용 입니다',
        ),
        token=android_token,
    )
    response = messaging.send(message)
    print('response:', response)


if __name__ == '__main__':
    init()
    sendFCMMessage()
