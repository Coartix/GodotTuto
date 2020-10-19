	org $4
	
Vector_001 dc.l Main

	org $500
	
Main move.l #-16,d0

Abs	tst.l d0
	bmi Negative
	bra quit
	
Negative NEG.l d0
	bra quit
	
quit illegal
	
