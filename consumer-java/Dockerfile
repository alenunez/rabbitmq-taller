FROM openjdk:17

WORKDIR /app

# Copiar archivos fuente y dependencias
COPY Consumer.java .
COPY amqp-client-5.18.0.jar .
COPY slf4j-api-1.7.36.jar .
COPY slf4j-simple-1.7.36.jar .

# Compilar el archivo Java
RUN javac -cp ".:amqp-client-5.18.0.jar:slf4j-api-1.7.36.jar:slf4j-simple-1.7.36.jar" Consumer.java

# Ejecutar el consumer
CMD ["java", "-cp", ".:amqp-client-5.18.0.jar:slf4j-api-1.7.36.jar:slf4j-simple-1.7.36.jar", "Consumer"]
