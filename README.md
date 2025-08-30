# libCow

**libCow** — a state-of-the-art .NET library for digital bovine simulation.
This library exists purely to inconvenience you and your application.

## License

GPL-3.0 — you are free to use, modify, and redistribute, but you must share alike.
Yes, that means your project might inherit a cow if you adopt one.

---

## Features

* Adopt a virtual cow with a single class instantiation.
* Stats include:

  * Hunger
  * Thirst
  * Stamina
* Background timer ticks every 2 seconds, slowly decreasing stats.
* Subscribe to `OnStateChanged` to get live “interrupt” updates.
* Interact with your cow via:

  * `moo(int volume)`
  * `eatGrass()`
  * `drinkWater()`
  * `sleep()`
* `getCowData()` returns a snapshot of current stats.

---

## Installation

Include `libCow.dll` in your project or reference it as a class library.

---

## Usage Example

```csharp
using System;
using libCow;

class Program
{
    static void Main()
    {
        var bessie = new cowStuff();

        // Subscribe to live updates
        bessie.OnStateChanged += state =>
        {
            Console.WriteLine($"Hunger:{state.Hunger}, Thirst:{state.Thirst}, Stamina:{state.Stamina}");
        };

        // Start the cow
        bessie.cow();

        // Interact with the cow
        Console.WriteLine(bessie.moo(12));
        bessie.eatGrass();
        bessie.drinkWater();
        bessie.sleep();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
```

---

## Warning

* **Do not ignore your cow.** Stats will decrease even if you’re not interacting.
* No milk, no meat, no tangible benefits — only background bovine responsibility.
* Multiple cows = multiple timers. You have been warned.

---

## Why?

Because sometimes, a library doesn’t need a reason. libCow exists as a monument to absurdity in .NET.

---

*Enjoy your cow.*

This REDAME was made by ChatGPT btw. i'm too lazy for this really.

Why does it exist? Good question.
