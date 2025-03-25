import pika
import time

time.sleep(15)

credentials = pika.PlainCredentials('miusuario', 'mipassword')
connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='rabbitmq', credentials=credentials)
)
channel = connection.channel()
channel.queue_declare(queue='hello')

counter = 1

try:
    while True:
        message = f"Mensaje {counter} desde Python Producer!"
        channel.basic_publish(exchange='', routing_key='hello', body=message)
        print(f"✅ [PYTHON PRODUCER] Enviado: {message}")
        counter += 1
        time.sleep(1)  # Espera 1 segundo entre cada mensaje
except KeyboardInterrupt:
    print("🛑 Interrumpido por el usuario.")
finally:
    priny("")
