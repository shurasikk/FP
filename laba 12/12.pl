%11 zadaniye
nod(0,B,B):-!.
nod(A,0,A):-!.
nod(A,B,R):-A>B, A1 is A mod B, nod(A1,B,R),!;B1 is B mod A, nod(A,B1,R),!.

prime(X,Y):-nod(X,Y,R),R=1.
%down
count_down(_,1,Count,OUT):-OUT is Count,!.
count_down(X,Y,Count,OUT):-Y>1,NY is Y-1,(not(prime(X,Y)),0 is Y mod 2,
    NCount is Count+1;NCount is Count),count_down(X,NY,NCount,OUT).
count_down(X, OUT):-NX is X-1,count_down(X,NX,0,OUT),!.
