read_str(A, N) :- read_str(A, N, 0).
read_str(A,N,Flag):-get0(X),r_str(X,A,[],N,0,Flag).
r_str(-1,A,A,N,N,1):-!.
r_str(10,A,A,N,N,0):-!.
r_str(X,A,B,N,K,Flag):-K1 is K+1,append(B,[X],B1),get0(X1),r_str(X1,A,B1,N,K1,Flag).

read_str_f(A,N,Flag):-get0(X),r_str_f(X,A,[],N,0,Flag).
r_str_f(-1,A,A,N,N,0):-!.
r_str_f(10,A,A,N,N,1):-!.
r_str_f(X,A,B,N,K,Flag):-K1 is K+1,append(B,[X],B1),get0(X1),r_str_f(X1,A,B1,N,K1,Flag).

lenght([],C,V):-V is C.
lenght([_|T],C,V):-C1 is C+1,lenght(T,C1,V).
lenght([H|T],V):-lenght([H|T],0,V).

read_list_str(List,List_len):-read_str_f(A,N,Flag),r_l_s(List,List_len,[A],[N],Flag).
r_l_s(List,List_len,List,List_len,0):-!.
r_l_s(List,List_len,Cur_list,Cur_list_len,_):-
	read_str_f(A,N,Flag),append(Cur_list,[A],C_l),
        append(Cur_list_len,[N],C_l_l),r_l_s(List,List_len,C_l,C_l_l,Flag).

write_str([]):-!.
write_str([H|Tail]):-put(H),write_str(Tail).

in_list([],_):-fail.
in_list([H|_],H).
in_list([_|T],El):-in_list(T,El).

in_list_exclude([H|T],H,T).
in_list_exclude([H|T],El,[H|Tail]):-in_list_exclude(T,El,Tail).

%1.1 zadaniye
task1_1 :- write('Write your string: '), read_str(Str, Len), write_str(Str),
    write(', '), write_str(Str), write(', '), write_str(Str), nl, write('Length: '), write(Len).

%1.2 zadaniye
count_words([],N,_,N):-!.
count_words([32|T],N,false,V):-count_words(T,N,false,V).
count_words([_|T],N,false,V):-N1 is N+1,count_words(T,N1,true,V).
count_words([32|T],N,true,V):-count_words(T,N,false,V).
count_words([_|T],N,true,V):-count_words(T,N,true,V).
count_words([32|T],N):-count_words(T,N).
count_words([_|T],N):-count_words(T,1,true,N).

task1_2:- write('Write your string: '),read_str(S,_),count_words(S,N),write(N),!,nl.

%1.3 zadaniye

get_words([],[[]],_).
get_words([32|T],Tail,0):-get_words(T,Tail,0),!.
get_words([32|T],[[]|Tail],_):-get_words(T,Tail,0),!.
get_words([H|T],[[H|T2]|Tail],N):-N1 is N+1,get_words(T,[T2|Tail],N1),!.
get_words(List,Out):-get_words(List,Out,0).


count_item(List,El,C,V,Out):-in_list_exclude(List,El,List1),!,
    (C1 is C+1,count_item(List1,El,C1,V,Out));Out = List,V is C.
count_item(List,El,V,Out):-count_item(List,El,0,V,Out),!.

count_list([],[]).
count_list([H|T],[H2|T2]):-count_item([H|T],H,V,L2),H2 = [H,V],count_list(L2,T2).

find_max([],_,Item,Item).
find_max([[H1,H2]|T],Max,Item,Out):-(Max < H2,Max1 is H2,Item1 = H1;Max1 is Max,
                                     Item1 = Item),find_max(T,Max1,Item1,Out).
find_max([[H1,H2]|T],Out):-find_max(T,H2,H1,Out),!.

task1_3:-write('Write your string: '),read_str(S,_),get_words(S,S1),count_list(S1,Out),find_max(Out,MAX),write_str(MAX).

%1.4 zadaniye
first_three([H1,H2,H3|_]):-put(H1),put(H2),put(H3),nl,!.

last_three([H1,H2,H3|[]]):-put(H1),put(H2),put(H3),nl,!.
last_three([_|T]):-last_three(T).

put_n(_,0):-!.
put_n([H|T],N):-N1 is N-1,put(H),put_n([H|T],N1).

task1_4:-write('Write your string: '),read_str(S,N),(N>5,(first_three(S),last_three(S)),!;put_n(S,N)).

%1.5 zadaniye
last([H|[]],H).
last([_|T],S):-last(T,S).

indexed([],_,_,[]).
indexed([H|T],H,I,[I|T2]):-I1 is I+1,indexed(T,H,I1,T2).
indexed([_|T],El,I,T2):-I1 is I+1,indexed(T,El,I1,T2).
indexed(List,El,Ans):-indexed(List,El,0,Ans),!.

prnt([]):-nl,!.
prnt([H|T]):-write(H),write(' '),prnt(T).

task1_5:-write('Write your string: '),read_str(S,_),last(S,M),
    indexed(S,M,N),prnt(N),!.

%2.1 zadaniye

max_lenght([],_,S,S):-!.
max_lenght([H|T],M,MaxStr,Ans):-lenght(H,V),
    (V>M,M1 is V,M2 = H;M1 is M,M2 = MaxStr),
    max_lenght(T,M1,M2,Ans).
max_lenght([H|T],Ans):-lenght(H,L),max_lenght(T,L,H,Ans).

task2_1:-see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.1.txt'),
    read_list_str(List,_),seen,max_lenght(List,Ans),length(Ans,N),write(N),!.

%2.2 zadaniye
final_check([],V,V):-!.
final_check([H|T],N,Ans):-(not(in_list(H,32)),N1 is N+1,!;N1 is N),
    final_check(T,N1,Ans).
final_check(List,Ans):-final_check(List,0,Ans).

task2_2:-see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.2.txt'),
    read_list_str(List,_),seen,final_check(List,N),write(N),nl,!.

%2.3 zadaniye
sum([],S,S):-!.
sum([H|T],S,Ans):-S1 is S + H,sum(T,S1,Ans).
sum(List,Sum):-sum(List,0,Sum).

average(List,Out):-length(List,L),sum(List,S),Out is S div L.

a_count([],V,V):-!.
a_count([97|T],N,Ans):-N1 is N+1,a_count(T,N1,Ans).
a_count([65|T],N,Ans):-N1 is N+1,a_count(T,N1,Ans).
a_count([_|T],N,Ans):-a_count(T,N,Ans).
a_count(List,Ans):-a_count(List,0,Ans),!.

a_list_count([],[]):-!.
a_list_count([H|T],[H2|T2]):-a_count(H,C),H2 is C,a_list_count(T,T2).

print_greater([],_).
print_greater([H|T],Av):-a_count(H,C),(C>Av,write_str(H),nl;true),print_greater(T,Av).

task2_3:-see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.3.txt'),
    read_list_str(List,_),seen, a_list_count(List,CntList),average(CntList,Av),
    print_greater(List,Av),!.

%2.4 zadaniye
read_all_str(S,N):-get0(X),r_a_str(S,N,0,[],X).
r_a_str(S,N,N,S,-1):-!.
r_a_str(S,N,K,TS,10):-NewK is K,append(TS,[32],NewTS),get0(NewX),
	r_a_str(S,N,NewK,NewTS,NewX).
r_a_str(S,N,K,TS,X):-NewK is K + 1,append(TS,[X],NewTS),get0(NewX),
	r_a_str(S,N,NewK,NewTS,NewX).


task2_4:-see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.4.txt'),
    read_all_str(S,_),seen,get_words(S,S1),count_list(S1,Ans),
    find_max(Ans,Max),write_str(Max),!.

%2.5 zadaniye
check_unique(List,El):-in_list_exclude(List,El,W),not(in_list(W,El)),!.

line_unique([],_):-!.
line_unique([H|T],WordList):-check_unique(WordList,H),line_unique(T,WordList).

check_line(Line,Words):-get_words(Line,WList),line_unique(WList,Words).

check_all_lines([],_):-!.
check_all_lines([H|T],Words):-(check_line(H,Words),write_str(H),nl;true),
	check_all_lines(T,Words).

task2_5:-see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.5.txt'),
	read_list_str(List,_),seen,!,
		 see('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.5.txt'),
		 read_all_str(WList,_),seen,!,
		 get_words(WList,Words),
		 tell('C:/Users/Asus/Documents/GitHub/FP/laba 14/2.5test.txt'),
		 check_all_lines(List,Words),told.
