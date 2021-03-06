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

%17 zadaniye
max_not_div3(0,-1):-!.
max_not_div3(X,Y):-X1 is X div 10, max_not_div3(X1, C1),
    C2 is X mod 10, (C2>C1, C2 mod 3 =\= 0, Y is C2; Y is C1).

%18 zadaniye
maxD_not_div3(0,CurMax,Max):-Max is CurMax,!.
maxD_not_div3(X,CurMax,Max):- X1 is X div 10, M is X mod 10,
    (M>CurMax,M mod 3 =\= 0,maxD_not_div3(X1,M,Max);maxD_not_div3(X1,CurMax,Max)),!.
maxD_not_div3(X,Max):-maxD_not_div3(X,-1,Max).

%19 zadaniye
fib(1,1):-!.
fib(2,1):-!.
fib(N,X):-N1 is N-1, N2 is N-2, fib(N1, X1), fib(N2,X2), X is X1+X2,!.

%20 zadaniye
fibD(N,X):- fibD(1,1,N,X,2),!.
fibD(F1,F2,N,X,C):- C<N,Fn1 is F2, Fn2 is F1+F2,
    C1 is C+1, fibD(Fn1,Fn2,N,X,C1),!.
fibD(_,F,N,X,N):- X is F,!.


