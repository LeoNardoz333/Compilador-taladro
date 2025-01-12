#include <Taladro.h>
void Funciones::atornillar(int pin, int pin2, int velocidad)
{
    analogWrite(pin, (velocidad*12)+110);
    digitalWrite(pin2, 0);
}
void Funciones::desatornillar(int pin, int pin2, int velocidad)
{
    analogWrite(pin2, (velocidad*12)+110);
    digitalWrite(pin, 0);
}
void Funciones::tiempo(int segundos)
{
    delay(segundos*1000);
}
void Funciones::apagar(int pin, int pin2)
{
    digitalWrite(pin,0);
    digitalWrite(pin2,0);
}