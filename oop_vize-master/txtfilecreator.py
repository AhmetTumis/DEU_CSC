#!/usr/bin/env python3

import random

file = open("sinema.txt", "w")

durum = ["dolu", "boş", "boş"]
a=1
b=1
c=1 
siraSayisi=0
salonSayisi=0
koltukSayisi=0

salonSayisi = int(input("Salon sayısını gir: "))
siraSayisi = int(input("Sıra sayısın gir: "))
koltukSayisi = int(input("Koltuk sayısını gir: "))

for a in range(salonSayisi):
    for b in range(siraSayisi):
        for c in range(koltukSayisi):
            d = random.choice([0,1,2])
            file.write("{},{},{},{}\n".format(a+1,b+1,c+1,durum[d]))

print("dosya oluşturuldu!")