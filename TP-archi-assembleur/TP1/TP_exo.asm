	org $4
Vector_001 dc.l Main
	org $500
Main move.b #$B4,d0
	move.b #$4C,d1 
	add.b d0,d1 
	illegal
