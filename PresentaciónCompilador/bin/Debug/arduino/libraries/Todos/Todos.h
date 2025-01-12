//Libreria de cabecera
#ifndef Todos_h
#define Todos_h
#include <Arduino.h>
class Todos
{
  public :
  void Led(int pin,int valor,int t);
  int Boton(int pin);
};
#endif