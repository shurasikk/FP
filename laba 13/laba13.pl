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

%16 zadaniye
task16:-
    Friends = [_,_,_],
    in_list(Friends,[slesar,_,youngest]),
    in_list(Friends,[tokar,_,_]),
    in_list(Friends,[svar,_,_]),
    in_list(Friends,[_,borisov,has_sibling]),
    in_list(Friends,[_,ivanov,_]),
    in_list(Friends,[_,semenov,older]),
    not(in_list(Friends,[slesar,_,older])),
    not(in_list(Friends,[slesar,_,has_sibling])),
    in_list(Friends,[slesar,Name1,_]),
    in_list(Friends,[tokar,Name2,_]),
    in_list(Friends,[svar,Name3,_]),
    write("??????? - "), write(Name1),nl,
    write("?????? - "), write(Name2), nl,
    write("??????? - "),write(Name3),!.

%17 zadaniye
sprava_next(_,_,[_]):-fail.
sprava_next(A,B,[A,B|_]).
sprava_next(A,B,[_|List]):-sprava_next(A,B,List).

sleva_next(_,_,[_]):-fail.
sleva_next(A,B,[B,A|_]).
sleva_next(A,B,[_|List]):-sleva_next(A,B,List).

between(List,X,Y,Z):-sleva_next(X,Y,List),sprava_next(Z,Y,List);
sleva_next(Z,Y,List),sprava_next(X,Y,List).

near(List,X,Y):-sprava_next(Y,X,List).
near(List,X,Y):-sleva_next(Y,X,List).

task17:-
    Drinks = [_,_,_,_],
    in_list(Drinks,[bottle,_]),
    in_list(Drinks,[glass,_]),
    in_list(Drinks,[jug,_]),
    in_list(Drinks,[jar,_]),
    in_list(Drinks,[_,milk]),
    in_list(Drinks,[_,lemonade]),
    in_list(Drinks,[_,kvas]),
    in_list(Drinks,[_,water]),
    not(in_list(Drinks,[bottle,milk])),
    not(in_list(Drinks,[bottle,water])),
    not(in_list(Drinks,[jar,lemonade])),
    not(in_list(Drinks,[jar,water])),
    between(Drinks,[jug,_],[_,lemonade],[_,kvas]),
    near(Drinks,[glass,_],[jar,_]),
    near(Drinks,[glass,_],[_,milk]),
    write(Drinks),!.

%18 zadaniye
task18:-
    Artists = [_,_,_,_],
    in_list(Artists,[voronov,_]),
    in_list(Artists,[levitskiy,writer]),
    in_list(Artists,[pavlov,_]),
    in_list(Artists,[saharov,_]),
    in_list(Artists,[_,dancer]),
    in_list(Artists,[_,painter]),
    in_list(Artists,[_,singer]),
    not(in_list(Artists,[voronov,singer])),
    not(in_list(Artists,[pavlov,painter])),
    not(in_list(Artists,[voronov,painter])),
    write(Artists),!.

%19 zadaniye
task19:-
    Sportsman=[_,_,_],
    in_list(Sportsman,[michael,_,basketball,2]),
    in_list(Sportsman,[_,american,_,3]),
    in_list(Sportsman,[saimon,israeli,_,_]),
    in_list(Sportsman,[_,_,cricket,1]),
    in_list(Sportsman,[Name,australian,_,_]),
    in_list(Sportsman,[richard,_,Sport,_]),
    in_list(Sportsman,[_,_,tennis,_]),
    write("Australian is "), write(Name), nl,
    write("Richard sport - "), write(Sport),!.

%20 zadaniye
check_unique([],true).
check_unique([[_,_,false]|T],true):-check_unique(T,true).
check_unique([[_,_,true]|_],true):-fail.
check_unique([[_,_,false]|T]):-check_unique(T).
check_unique([[_,_,true]|T]):-check_unique(T,true).


check_one([],0).
check_one([],1).
check_one(_,2):-fail.
check_one([[_,false,_]|T],N):-N1 is N+1,check_one(T,N1).
check_one([[_,true,_]|T],N):-check_one(T,N).
check_one([[_,false,_]|T]):-check_one(T,1).
check_one([[_,true,_]|T]):-check_one(T,0).

task20:- Children=[_,_,_,_,_],
	in_list(Children,[andrew,_,_]),
	in_list(Children,[vitya,_,_]),
	in_list(Children,[dima,_,_]),
	in_list(Children,[yura,_,_]),
	in_list(Children,[kolya,true,_]),
	in_list(Children,[_,true,_]),
	in_list(Children,[_,false,_]),
	in_list(Children,[_,_,false]),
	in_list(Children,[_,_,true]),
       (in_list(Children,[andrew,true,_])->
		(in_list(Children,[vitya,_,true]);
		in_list(Children,[kolya,_,true]));
		not((in_list(Children,[vitya,_,true]);
		in_list(Children,[kolya,_,true])))),
	(in_list(Children,[vitya,true,_])-> (
		in_list(Children,[vitya,_,false]),
		in_list(Children,[yura,_,false]));
		not((in_list(Children,[vitya,_,false]),
		in_list(Children,[yura,_,false])))),
	(in_list(Children,[dima, true, _])-> (
		(in_list(Children,[andrew,true,_]),
		in_list(Children,[vitya,false,_]));
		(in_list(Children,[andrew,false,_]),
		in_list(Children,[vitya,true,_])));not(
		(in_list(Children,[andrew,true,_]),
		in_list(Children,[vitya,false,_]));
		(in_list(Children,[andrew,false,_]),
		in_list(Children,[vitya,true,_])))),
	(in_list(Children,[yura,true,_])->
		in_list(Children,[dima,false,_]);
		in_list(Children,[dima,true,_])),
        check_one(Children),
	check_unique(Children),
	write(Children),nl,!.



