#include <Taladro.h>
Funciones t;
void setup()
{
pinMode(11,OUTPUT);
pinMode(10,OUTPUT);
}
void loop()
{
int kita = 3;
t.tiempo(kita+2);
if((((kita+3)*12)+100) > 230)
  t.atornillar(11,10,230);
else
  t.atornillar(11,10,kita+3);
t.tiempo(kita);
t.apagar(11,10);
t.tiempo(1);
if(((kita*12)+100) > 230)
  t.desatornillar(11,10,230);
else
  t.desatornillar(11,10,kita);
t.tiempo(kita-1);
t.apagar(11,10);
}
