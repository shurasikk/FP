man(ivan).
man(alexandr).
man(nikolay).
man(aleksey).
man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).
woman(galina).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).
parent(galina,ivan).
parent(ivan,nikolay).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

%11 zadaniye

father(X,Y):-man(X),parent(X,Y),!.
father(X):-father(X,Y),write(X),nl.

%12 zadaniye
wife(X,Y):-woman(X),parent(X,Z),parent(Y,Z),nl.
wife(X):-wife(X,Y), write(X), nl,!.

%13 zadaniye
grand_ma(X, Y):-woman(X),parent(X,Z),parent(Z,Y),!.
grand_mas(X):-grand_ma(X,Y),write(X),nl.

%14 zadaniye
grand_ma_and_son(X,Y):-grand_ma(X,Y),man(Y),!;man(X),grand_ma(Y,X),!.

%15 zadaniye
proiz_cifr(X,Y):-X<10, Y is X mod 10, !.
proiz_cifr(X,Y):-X>=10, X1 is X div 10, proiz_cifr(X1,P), Y is (X mod 10)*P,!.

%16 zadaniye
down_proiz_cifr(X,Y,Res):-X<10, Y1 is Y*(X mod 10), Res is Y1,write(Res),!.
down_proiz_cifr(X,Y,Res):-X>=10, X1 is X div 10, Y1 is Y*(X mod 10),down_proiz_cifr(X1,Y1,Res),!.
down_mult(X):-down_proiz_cifr(X,1,Res),!.
