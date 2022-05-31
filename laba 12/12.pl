%11 zadaniye
nod(0,B,B):-!.
nod(A,0,A):-!.
nod(A,B,R):-A>B, A1 is A mod B, nod(A1,B,R),!;B1 is B mod A, nod(A,B1,R),!.

prime(X,Y):-nod(X,Y,R),R=1.
%down
count_down(_,1,Count,OUT):-OUT is Count,!.
count_down(X,Y,Count,OUT):-NY is Y-1,(not(prime(X,Y)),0 is Y mod 2,
    NCount is Count+1;NCount is Count),count_down(X,NY,NCount,OUT).
count_down(X, OUT):-NX is X-1,count_down(X,NX,0,OUT),!.
%up
count_up(_,1,0).
count_up(X,Y,Count):-NY is Y-1, count_up(X,NY,NCount),
    (not(prime(X,Y)),0 is Y mod 2, Count is NCount+1; Count is NCount),!.
count_up(X,Y):-C is X-1, count_up(X,C,Y).

%12 zadaniye
mindel(X,X,Z):-Z is X,!.
mindel(X,Y,Z):- 0 is X mod Y,Z is Y;Y1 is Y + 1,mindel(X,Y1,Z).
mindel(X,Y):-mindel(X,2,Y),!.

max_notprime(X,Y):-X1 is X-1,mindel(X,D),max_notprime(X,X1,D,Y).
max_notprime(_,1,_1):-!.
max_notprime(X,I,D,Y):-I mod D =\= 0, not(prime(X,I)), Y is I;
I1 is I-1, max_notprime(X,I1,D,Y),!.

sumcifr(0,0):-!.
sumcifr(X,Y):-X1 is X div 10, sumcifr(X1,Y1),
     (P is X mod 10, P<5, Y is Y1+P;Y is Y1),!.

mult(X,Y):-max_notprime(X,D),sumcifr(X,S),Y is D*S.

%14 zadaniye
length_list([],0):-!.
length_list([_|T], L) :- length(T,I), L is I + 1.

%write read list
readList(0,[]) :- !.
readList(I,[X|T]) :- write('input - '),read(X), I1 is I - 1, readList(I1, T).

write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).

%15 zadaniye (3)
find_max([],Max,Max):-!.
find_max([H|T],Max,Result):-(H>Max,Max1 is H;
                            Max1 is Max),
    find_max(T,Max1,Result).
find_max([H|T],Max):-find_max(T,H,Max),!.

find_ind([],_,_,_):- false.
find_ind([H|T],N,I,V):-I is N,V is H;I1 is I+1,find_ind(T,N,I1,V).
find_ind([H|T],N,V):-find_ind([H|T],N,0,V),!.

check_ind([H|T],N):-find_max([H|T],M),find_ind([H|T],N,M).

%17 zadaniye (14)
count_interval([],_,_,C,C).
count_interval([H|T],A,B,C,Count):-((A<H,B>H),C1 is Count+1;C1 is Count),
    count_interval(T,A,B,C,C1).
count_interval(List,A,B,C):-count_interval(List,A,B,C,0),!.

%16 zadaniye (4)
find_ind_max([],_,MC,_,MC).
find_ind_max([H|T],M,MC,IND,Res):-(H>M,MAX is H,MAXC is IND;MAX is M, MAXC is MC),
    IND1 is IND+1,find_ind_max(T,MAX,MAXC,IND1,Res).
find_ind_max([H|T],Res):-find_ind_max(T,H,0,1,Res),!.

% delete with index
del([],_,_,_).
del([_|T],C,C,T).
del([H|T],IND,C,[H|L]):-IND1 is IND+1,del(T,IND1,C,L),!.
del([H|T],C,A):-del([H|T],0,C,A).

sorted([],_):-!.
sorted([H|T],[L|T1]):-find_max([H|T],L),find_ind_max([H|T],M),del([H|T],M,NL),
    sorted(NL,T1),!.

% find ind with elem
find_el([],_,_,A):-A is -1,false.
find_el([H|T],IND,EL,A):-EL is H,A is IND,true;IND1 is IND+1,find_el(T,IND1,EL,A).
find_el([H|T],EL,A):-find_el([H|T],0,EL,A),!.

sorted_ind([],_,_).
sorted_ind([H|T],LST,[H1|T1]):-find_el(LST,H,H1),sorted_ind(T,LST,T1).
sorted_ind(LIST,OUTPUT):-sorted(LIST,SCND),sorted_ind(SCND,LIST,OUTPUT),!.

%13 zadaniye
prost(X,X):- true,!.
prost(X,Y):- X>Y, 0 is X mod Y -> false;Y1 is Y+1,prost(X,Y1).
prost(X):- X>1,prost(X,2),!;false,!.

count(B,C,CNT,N,Z):-NM is (N*N+B*N+C),(prost(NM),NCNT is CNT+1,NN is N+1,
                                       count(B,C,NCNT,NN,Z);Z is CNT),!.
count(B,C,Z):-count(B,C,0,0,Z).


polynom(999,999,M,PR,V):- count(999,999,M1),(M1>M,NPR is 999*999;NPR is PR),
    V is NPR,!.
polynom(B,C,M,PR,V):-THS is 1000,count(B,C,M1),(M1 > M,(MAX is M1,NPR is B*C);
                                               MAX is M,
    NPR is PR),(THS > C,(C1 is C+1,B1 is B);B1 is B+1,C1 is -999),
    polynom(B1,C1,MAX,NPR,V).

find(V):-polynom(-999,-999,0,0,V).

%18 zadaniye (16)
second_max(List,L):-find_max(List,_),find_ind_max(List,I),del(List,I,List1),
    find_max(List1,L),!.


find_in_interval(_,I2,I2,I2,[]):-!.
find_in_interval([H|T],I1,I2,I,NewList):-NI is I+1,
    find_in_interval(T,I1,I2,NI,NewList).
find_in_interval([H|T],I1,I2,I1,[H|NewList]):-IN is I1+1, NI is I1+1,
    find_in_interval(T,IN,I2,NI,NewList).



between_two_max(List,NewList):-find_max(List,MAX1),second_max(List,MAX2),
find_el(List,MAX1,I1),find_el(List,MAX2,I2), I11 is I1+1,
    find_in_interval(List,I11,I2,0,NewList).

%19 zadaniye (25)
find_interval_max([],_,_,_,Max,Max).
find_interval_max([H|T],A,B,I,M,Max):-((A=<I,B>=I,H>M),M1 is H;M1 is M),
    I1 is I+1,find_interval_max(T,A,B,I1,M1,Max).
find_interval_max([H|T],A,B,Max):-find_interval_max(T,A,B,1,H,Max),!.

%20 zadaniye (28)
find_ind_secondmax([],_,MC,_,MC).
find_ind_secondmax([H|T],M,MC,IND,Res):-(H>=M,MAX is H,MAXC is IND;MAX is M, MAXC is MC),
    IND1 is IND+1,find_ind_secondmax(T,MAX,MAXC,IND1,Res).
find_ind_secondmax([H|T],Res):-find_ind_secondmax(T,H,0,1,Res),!.

between_first_last_max(List,NewList):-find_ind_max(List,I1),
    find_ind_secondmax(List,I2), find_in_interval(List,I1,I2,0,NewList).






