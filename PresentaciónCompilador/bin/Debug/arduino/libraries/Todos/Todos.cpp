//Archivo de código
#include <Todos.h>
void Todos::Led(int pin, int valor, int t);
{
  digitalWrite(pin,valor);delay(t);
}

int Todos::Boton(int pin)
{
  return digitalRead(pin);
}