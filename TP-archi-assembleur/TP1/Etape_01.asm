	org $4  ;precise a partir de quelle adresse seront assembles les lignes suivantes, l'adresse $0 a l'adresse $3FF sont pour les vecteurs d'exception
Vector_001 dc.l Main   ;place l'adresse Main(point d'entree de notre programme) a l'adresse $4
	;Ces deux premières lignes devront être présentes dans tous vos codes sources afin d’initialiser correctement le 68000.
	org $500		;programme principal a l'adresse $500
Main move.b #$41,d0	;plusieurs instructions MOVE qui serviront à initialiser certains registres de donnée à l’aide de données immédiates
	move.w #65535,d1
	move.l #-5,d2
