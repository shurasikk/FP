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
