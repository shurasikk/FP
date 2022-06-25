readlist(X,Y):-readlist([],X,0,Y).
readlist(A,A,G,G):-!.
readlist(A,B,C,D):- C1 is C+1,read(X),append(A,[X],A1),readlist(A1,B,C1,D).

write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).

in_list([El|_],El).
in_list([_|T],El):-in_list(T,El).

%zadaniye 11 (40)
first_ch([],_):-false.
first_ch([H|T],Out):-0 is H mod 2,Out is H;first_ch(T,Out),!.

min([],M,M).
min([H|T],M,Min):-(H<M,0 is H mod 2,M1 is H;M1 is M),min(T,M1,Min).
min(List,Min):-first_ch(List,F),min(List,F,Min),!.


%13 zadaniye (46)

add([],[H|T],[H|T]):-!.
add(E,[],[E]).
add(E,[H|T],[H|T1]):-add(E,T,T1).

listNegative(X,Res):-listNegative(X,Res,[]),!.
listNegative([],Res,Res):-!.
listNegative([H|T],Res,CurL):-(H<0,add(H,CurL,NewL);append([],CurL,NewL)),
    listNegative(T,Res,NewL),!.

listPositive(X,Res):-listPositive(X,Res,[]),!.
listPositive([],Res,Res):-!.
listPositive([H|T],Res,CurL):-(H>=0,add(H,CurL,NewL);add([],CurL,NewL)),
    listPositive(T,Res,NewL),!.

list_p_and_n(X,Res):- listPositive(X,Pos), listNegative(X,Neg), append(Pos,Neg,Res),!.

%13 zadaniye (52)
prost(X,X):- true,!.
prost(X,Y):- X>Y, 0 is X mod Y -> false;Y1 is Y+1,prost(X,Y1).
prost(X):- X>1,prost(X,2),!;false,!.

dividers(1,_,[]).
dividers(N,P,[H|T]):-prost(P),0 is N mod P,N1 is N div P,H is P,
    dividers(N1,2,T);P1 is P+1,dividers(N,P1,[H|T]).
dividers(N,Res):-dividers(N,2,Res),!.

%14 zadaniye
task14:-
    Hair_colour = [_,_,_],
    in_list(Hair_colour,[belokurov,_]),
    in_list(Hair_colour,[chernov,_]),
    in_list(Hair_colour,[ryzhov,_]),
    in_list(Hair_colour,[_,blond]),
    in_list(Hair_colour,[_,black]),
    in_list(Hair_colour,[_,redhead]),
    not(in_list(Hair_colour,[belokurov,blond])),
    not(in_list(Hair_colour,[chernov,black])),
    not(in_list(Hair_colour,[ryzhov,redhead])),
    write(Hair_colour),!.

%15 zadaniye
task15:-
    Look = [_,_,_],
    in_list(Look,[natasha,_,green]),
    in_list(Look,[anya,X,X]),
    in_list(Look,[valya,_,_]),
    in_list(Look,[_,white,_]),
    in_list(Look,[_,green,_]),
    in_list(Look,[_,blue,_]),
    in_list(Look,[_,_,white]),
    in_list(Look,[_,_,green]),
    in_list(Look,[_,_,blue]),
    not(in_list(Look,[valya,white,_])),
    not(in_list(Look,[valya,_,white])),
    not(in_list(Look,[valya,Y,Y])),
    not(in_list(Look,[natasha,Z,Z])),
    write(Look),!.
