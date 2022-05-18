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
grand_ma(X, Y):-woman(X),parent(X,Z),parent(Z,Y).
grand_mas(X):-grand_ma(X,Y),write(X),nl.


