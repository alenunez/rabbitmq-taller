import pika
import time

time.sleep(10)
credentials = pika.PlainCredentials('miusuario', 'mipassword')
parameters = pika.ConnectionParameters(host='rabbitmq', credentials=credentials)

while True:
    try:
        connection = pika.BlockingConnection(parameters)
        break
    except pika.exceptions.AMQPConnectionError:
        print("⏳ Esperando RabbitMQ...")
        time.sleep(5)

channel = connection.channel()
channel.queue_declare(queue='hello')

def callback(ch, method, properties, body):
    print(f"📥 [PYTHON CONSUMER] Mensaje recibido: {body.decode()}")

channel.basic_consume(queue='hello', on_message_callback=callback, auto_ack=True)
print("🔄 [PYTHON CONSUMER] Esperando mensajes...")
channel.start_consuming()
