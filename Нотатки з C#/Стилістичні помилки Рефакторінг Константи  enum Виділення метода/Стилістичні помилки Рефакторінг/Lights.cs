﻿namespace Стилістичні_помилки_Рефакторінг
{
    //По моувчанню значення Light кастуютьса за indx тодто
    //Red кастується до 0, Yellow кастоється як 1 і так далі

    //Але можна явно показати як має кастуватися значена Light
    enum Lights
    {
        Red = 0,  //0 в Red Це цілочислена костанта 
        Yellow = 1,
        Green = 2,
    }
}
