man(ivan).
man(alexandr).
man(nikolay).
man(aleksey).

parent(ivan, vladimyr).
parent(nikolay, viktoriya).

%11 �������

father(X,Y):-man(X),parent(X,Y),!.
father(X):-father(X,Y),write(X),nl.
