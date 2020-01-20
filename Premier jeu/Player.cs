using Godot;
using System;

public class Player : Area2D
{
	[Signal]
	public delegate void Hit();
	
	[Export]
	public int Speed = 400; //How fast the player will move (pixels/sec)
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
	private Vector2 _screenSize; //Size of the game window
    // Called when the node enters the scene tree for the first time.
    
	public override void _Ready()
    {
        _screenSize = GetViewport().GetSize();
		Hide();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
    {
        var velocity = new Vector2(); // The player's movement vector.

    	if (Input.IsActionPressed("ui_right"))
    	{
    	    velocity.x += 1;
    	}

    	if (Input.IsActionPressed("ui_left"))
    	{
        	velocity.x -= 1;
    	}

    	if (Input.IsActionPressed("ui_down"))
	    {
	        velocity.y += 1;
	    }
	
	    if (Input.IsActionPressed("ui_up"))
	    {
	        velocity.y -= 1;
	    }
	
	    var animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite"); //$ peut etre un raccourci pour get.node(). Exemple: $AnimatedSprite;
	
	    if (velocity.Length() > 0)
	    {
	        velocity = velocity.Normalized() * Speed; //Normalize est la pour mettre a la meme vitesse les mouvements a la fois vertical et horizontal 
	        animatedSprite.Play();
	    }
	    else
	    {
	        animatedSprite.Stop();
	    }
		
		Position += velocity * delta;  //Delta assure que le mouvement du player restera constant meme si les fps varient
		Position = new Vector2(
    	x: Mathf.Clamp(Position.x, 0, _screenSize.x),
    	y: Mathf.Clamp(Position.y, 0, _screenSize.y)); //Clamp permet de ne pas sortir de l'ecran
		
		if (velocity.x != 0)
		{
		    animatedSprite.Animation = "right";
		    // See the note below about boolean assignment
		    animatedSprite.FlipH = velocity.x < 0;
		    animatedSprite.FlipV = false;
		}
		else if(velocity.y != 0)
		{
		    animatedSprite.Animation = "up";
		    animatedSprite.FlipV = velocity.y > 0;
		}
		
	}
	
	private void _on_Player_body_entered(object body)
	{
		Hide(); // Player disappears after being hit.
    	EmitSignal("Hit");
    	GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);//Nous devons desactiver la collision du joueur afin de ne pas declencher le signal "hit" plus d'une fois et set_deferred evite les erreurs in doing so.
	}
	
	public void Start(Vector2 pos) //Reinitialise le joueur au debut d'une nouvelle partie
	{
    	Position = pos;
    	Show();
    	GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
	
}



