using System;

// abstrakcyjny interfejs dla różnych interfejsów wejściowych
public interface IInputInterface
{
    void SendData(byte[] data);
}

// konkretne implementacje interfejsu wejściowego
public class USBInputInterface : IInputInterface
{
    public void SendData(byte[] data)
    {
        Console.WriteLine("Wysyłanie danych przez USB: " + BitConverter.ToString(data));
    }
}

public class BluetoothInputInterface : IInputInterface
{
    public void SendData(byte[] data)
    {
        Console.WriteLine("Wysyłanie danych przez Bluetooth: " + BitConverter.ToString(data));
    }
}

// abstrakcyjna klasa dla urządzeń wejściowych
public abstract class InputDevice
{
    protected IInputInterface inputInterface;

    public InputDevice(IInputInterface inputInterface)
    {
        this.inputInterface = inputInterface;
    }

    public abstract void SendInputData(byte[] data);
}

// konkretne urządzenia wejściowe
public class Keyboard : InputDevice
{
    public Keyboard(IInputInterface inputInterface) : base(inputInterface)
    {
    }

    public override void SendInputData(byte[] data)
    {
        Console.WriteLine("Wysyłanie danych z klawiatury");
        inputInterface.SendData(data);
    }
}

public class Mouse : InputDevice
{
    public Mouse(IInputInterface inputInterface) : base(inputInterface)
    {
    }

    public override void SendInputData(byte[] data)
    {
        Console.WriteLine("Wysyłanie danych z myszy");
        inputInterface.SendData(data);
    }
}

// przykładowe użycie
class Program
{
    static void Main(string[] args)
    {
        IInputInterface usbInterface = new USBInputInterface();
        IInputInterface bluetoothInterface = new BluetoothInputInterface();

        InputDevice keyboard = new Keyboard(usbInterface);
        InputDevice mouse = new Mouse(bluetoothInterface);

        byte[] keyboardData = new byte[] { 0x01, 0x02, 0x03 };
        byte[] mouseData = new byte[] { 0x04, 0x05, 0x06 };

        keyboard.SendInputData(keyboardData);
        mouse.SendInputData(mouseData);
    }
}
