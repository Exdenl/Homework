using System;
using System.Timers;

public class AlarmClock
{
    public event EventHandler Tick;
    public event EventHandler Alarm;

    private System.Timers.Timer timer;
    private DateTime alarmTime;

    public AlarmClock()
    {
        timer = new System.Timers.Timer(1000);
        timer.Elapsed += OnTick;
    }

    public void SetAlarm(DateTime alarmTime)
    {
        this.alarmTime = alarmTime;
    }

    public void Start()
    {
        timer.Start();
        Console.WriteLine("闹钟开始走了！");
    }

    public void Stop()
    {
        timer.Stop();
        Console.WriteLine("闹钟已停止。");
    }

    private void OnTick(object sender, ElapsedEventArgs e)
    {
        Tick?.Invoke(this, EventArgs.Empty);

        if (DateTime.Now >= alarmTime)
        {
            Alarm?.Invoke(this, EventArgs.Empty);
            Stop();
        }
    }
}

class Program
{
    static void Main()
    {
        AlarmClock clock = new AlarmClock();

        clock.Tick += (sender, e) =>
        {
            Console.WriteLine("嘀嗒...");
        };

        clock.Alarm += (sender, e) =>
        {
            Console.WriteLine("响铃！时间到！");
        };

        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        clock.SetAlarm(alarmTime);

        clock.Start();

        Console.WriteLine($"闹钟时间已设置为: {alarmTime}");
        Console.WriteLine("按任意键停止闹钟...");
        Console.ReadKey();
    }
}
