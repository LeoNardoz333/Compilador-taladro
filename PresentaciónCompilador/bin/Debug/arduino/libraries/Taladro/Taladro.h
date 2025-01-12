#ifndef Taladro_H
#define Taladro_H
#include <Arduino.h>
class Funciones
{
    public:
    void atornillar(int pin, int pin2, int velocidad);
    void desatornillar(int pin, int pin2, int velocidad);
    void tiempo(int segundos);
    void apagar(int pin, int pin2);
};
#endif