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



