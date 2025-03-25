import com.rabbitmq.client.*;

public class Consumer {
    public static void main(String[] argv) throws Exception {
Thread.sleep(15000);
        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost("rabbitmq");
        factory.setUsername("miusuario");
        factory.setPassword("mipassword");
        Connection connection = factory.newConnection();
        Channel channel = connection.createChannel();

        channel.queueDeclare("hello", false, false, false, null);
        System.out.println("🔄 Esperando mensajes (Java Consumer)...");

        DeliverCallback deliverCallback = (consumerTag, delivery) -> {
            String message = new String(delivery.getBody(), "UTF-8");
            System.out.println("📥 Mensaje recibido: " + message);
        };
        channel.basicConsume("hello", true, deliverCallback, consumerTag -> {});
    }
}
