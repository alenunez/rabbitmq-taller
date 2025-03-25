import com.rabbitmq.client.*;

public class Producer {
    public static void main(String[] argv) throws Exception {
Thread.sleep(15000);
        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost("rabbitmq");
        factory.setUsername("miusuario");
        factory.setPassword("mipassword");

        try (Connection connection = factory.newConnection();
             Channel channel = connection.createChannel()) {

            channel.queueDeclare("hello", false, false, false, null);

            int i = 1;
            while (true) {
                String message = "Mensaje " + i++ + " desde Java Producer 🚀";
                channel.basicPublish("", "hello", null, message.getBytes("UTF-8"));
                System.out.println("📤 Enviado: " + message);
                Thread.sleep(2000); // Espera 2 segundos
            }
        }
    }
}
