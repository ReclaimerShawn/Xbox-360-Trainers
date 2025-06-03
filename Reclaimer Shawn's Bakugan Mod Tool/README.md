# Known Glitches
* Selecting a Bakugan that doesn't match with its attribute (EX: Haos Dragonoid) will a "Dummy Data" sprite instead of the ball model or the picture in-game. Mismatched Bakugan will also have black sprites. I view this a feature, not a bug due to how cool it looks, but this is due to how the game works.
* Viewing Naga's ball model causes the game to crash. I do not know how to get around this in battle other than by file editing the game, but I can get around it in the shop upgrade menu and the deck menu by using the following code:
```
byte[] NagaFix = {0x81, 0x0B, 0x00, 0x00, 0x2C, 0x08, 0x00, 0x42, 0x40, 0x82, 0x00, 0x08, 0x39, 0x00, 0x00, 0x00, 0x48, 0x2D, 0x49, 0x10}; //Prevents crash in Upgrade Menu by using Dragonoid sprite instead.
byte[] NagaFix2 = {0x81, 0x7D, 0x00, 0x10, 0x2C, 0x0B, 0x00, 0x42, 0x40, 0x82, 0x00, 0x08, 0x39, 0x60, 0x00, 0x00, 0x48, 0x26, 0x86, 0x58}; //Prevents crash in Deck Menu by using Dragonoid sprite instead.
byte[] Branch = {0x4B, 0xD2, 0xB6, 0xE4};
byte[] Branch2 = {0x4B, 0xD9, 0x79, 0x9C};
XRPC.SetMemory(0x820A6EA0, NagaFix);
XRPC.SetMemory(0x820A6E8C, NagaFix2);
XRPC.SetMemory(0x8237B7BC, Branch);
XRPC.SetMemory(0x8230F4F0, Branch2);
```

![Bakugan Tool UI](https://github.com/user-attachments/assets/ed55fc0a-2b5c-4db4-bc98-42d813428926)
