	org $4
Vector_001 dc.l Main
	org $500
	
Main movea.l #STRING,a0




	illegal
	
	org $550
	
STRING dc.b "Cette chaine comporte 36 caracteres.",0
