	;Initialisation des vecteurs;
	
	org $4
Vector_001 dc.l Main

	;Programme principal;
	
	org $500
	
Main movea.l #String1,a0
	jsr RemoveSpace

	movea.l #String2,a0
	jsr IsCharError
	
	movea.l #String3,a0
	jsr IsCharError
	
	
	illegal


	;Sous-Programmes;

	
RemoveSpace movem.l d0/a1/a0,-(a7)
		
	move.l #$600,a1   ;la ou on va stocker la bonne string, on pointe vers l'adresse $600
	

	clr.l d0
	
\loop move.b (a0)+,d0
	beq \quit
	
	cmp.b #' ',d0
	beq \loop
	
	move.b d0,(a1)+   ;on ajoute d0.b -> a1 et on incremente le pointeur
	bra \loop
	
\quit movem.l (a7)+,d0/a1/a0
	rts




IsCharError movem.l d0/a0,-(a7)
	clr.l d0
	
\loop move.b (a0)+,d0
	beq \false
	
	cmp.b #'0',d0
	blo \true
	
	cmp.b #'9',d0
	bhi \true
	bra \loop
	
\true ori.b #%00000100,ccr   ; Positionne le flag Z à 1 (true).
	bra \quit
	
\false andi.b #%11111011,ccr ; Positionne le flag Z à 0 (false).
	bra \quit
	
\quit movem.l (a7)+,d0/a0
	rts


	;Donnees;
	
String1 dc.b " 5 +  12* 3 ",0
String2 dc.b "512 ",0
String3 dc.b "5a12",0
