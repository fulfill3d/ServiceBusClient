
# ServiceBusClient

ServiceBusClient is a library designed to interact with Azure Service Bus. It provides functionalities to send messages to Service Bus queues or topics, with support for session-based messaging and timeout handling.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
5. [Usage](#usage)
6. [Configuration](#configuration)

## Introduction

ServiceBusClient provides a simple and efficient way to send messages to Azure Service Bus queues. It includes support for handling sessions and message timeouts, making it suitable for various messaging scenarios in distributed systems.

## Features

- **Send Message:** Send a message to a specified Service Bus queue or topic.
- **Session Support:** Send messages with a session ID for session-based processing.
- **Timeout Handling:** Send messages with a cancellation token to handle timeouts.

## Tech Stack

- **Backend:** .NET 8
- **Messaging:** Azure Service Bus
- **Dependency Injection:** Used for service registrations and configurations

## Usage

1. **Register the ServiceBusClient:** Use the `RegisterServiceBusClient` extension method to register the client in the dependency injection container.
2. **Configure the options:** Set up `ServiceBusClientOptions` with the necessary configuration, including the connection string.
3. **Send Messages:** Use the `SendMessage` and `SendMessageWithTimeout` methods to send messages to the Service Bus queue or topic.

## Configuration

### ServiceBusClientOptions

- **ConnectionString:** The connection string to the Azure Service Bus namespace.

```csharp
public class ServiceBusClientOptions
{
    public string ConnectionString { get; set; }
}
```