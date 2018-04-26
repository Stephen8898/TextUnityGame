using UnityEngine;
using UnityEngine.UI;
using System.Collections;

 

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom, corridor_0, stairs_0, floor, closet_door, stairs_1, corrider_1, in_closet,
		stairs_2, corridor_2, corridor_3, courtyard, corridor_1_N ,caught, free}
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	int x = 2;
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell)				{state_cell();}  
		else if(myState == States.sheets_0)		{state_sheets_0();} 
		else if(myState == States.mirror) 		{state_mirror();} 
		else if(myState == States.lock_0)		{state_lock_0();} 
		else if(myState == States.cell_mirror)	{state_cell_mirror();} 
	    else if(myState == States.sheets_1)		{state_sheets_1();} 
	    else if(myState == States.lock_1)		{state_lock_1();} 
	    else if(myState == States.freedom)		{state_freedom();}	
		else if(myState == States.caught)		{state_caught();}
	// Corrridor scene
		if(myState == States.corridor_0) 		{state_freedom();}
		else if(myState == States.stairs_0) 	{state_stairs_0();}
		else if(myState == States.floor) 		{state_floor();}
		else if(myState == States.closet_door) 	{state_closet_door();}
		else if(myState == States.stairs_1) 	{state_stairs_1();}
		else if(myState == States.corrider_1) 	{state_corridor_1();}
		else if(myState == States.in_closet) 	{state_in_closet();}
		else if(myState == States.stairs_2) 	{state_stairs_2();}
		else if(myState == States.corridor_2) 	{state_corridor_2();}
		else if(myState == States.corridor_3) 	{state_corridor_3();}
		else if(myState == States.courtyard) 	{state_courtyard();}
		else if(myState == States.corridor_1_N) {state_corridor_1_N();}
		else if(myState == States.caught)		{state_caught();}
		else if(myState == States.free)			{state_free();}
}

	void state_cell () {
		text.text = "You wake up in a room by yourself eyes glazed over with vague recollections " +
				"of events that may have transpired; the last thing you remember with clearity, " +
				"was waking up to fix some breakfast then; nothing.You come to yourself, "+
				"your enviroment explicetly invites you, that's when you realize without a doubt "+
				"this is \"Prison\". You want answers but first you must escape. There are dirty " +
				"sheets on the bed, a mirror on the wall, and the door is locked from the outside.\n"+
				"[Press S to view Sheets, M to view Mirror, and L to view Lock] "; 
		if(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;} 
		else if(Input.GetKeyDown(KeyCode.M))	{myState = States.mirror;} 
		else if(Input.GetKeyDown (KeyCode.L))	{myState = States.lock_0;}
	}

	
	void state_sheets_0 () {
		text.text = "This thing is filthy but what choice do I have, it's freezing. "+
					"The logo on the sheet seems very familier but I just can't "+
					"put a finger on it. \n\n"+
		   			"[Press R to Return to roaming cell]"; 
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
		
	}
	void state_lock_0 (){
		text.text = "Lock is tight can't get out of this cell hmm.. maybe I should "+
					"look at the mirror. \n\n "+
					"[Press R to Return to roaming cell]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	} 
	void state_mirror () {
		text.text = "Here's the mirror. I look ok but what is this scar? It's small "+
					"don't remember gettting this. Hmm...I wonder if this mirror can " + 
				    "aid in my escape.  \n\n"+
					"[Press R to Return to roaming cell or T to Take mirror to cell]"; 
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;} 
		else if(Input.GetKeyDown(KeyCode.T))	{myState = States.cell_mirror;} 
	}
	void state_cell_mirror () {
		text.text = "Ok, so how do I use this mirror to get out of here? Hmm... "+
					"Hmm... Ok I got an idea; time to get this engineer's mind working. \n\n"+
					"[Press S to Sheets or L to Lock]";
		if(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;} 
		else if(Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}
			
	}
	void state_sheets_1 (){
		text.text = "I got it! These sheets look like the one's I had "+
					"when I went over to grandmama's, \"contemplating...\" good times "+
					"but I wonder, why use this brand of sheets? \n\n" +
					"[Press R to Return to cell]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
	}
	void state_lock_1 (){
		text.text = "Ahh, I'm familier with these locks. So, if I do this with the mirror, "+
					"then that, and maybe put this here then voila got it open \n\n"+
					"[Press R to Return to cell or O to Open cell] ";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;} 
		else if(Input.GetKeyDown(KeyCode.O))	{myState = States.freedom;}
	}
	// End of Cell Scene, beginning of Corridor Scene
	void state_freedom (){
			
		text.text = "Im out! Yes, now I'm in the corridor but there's no way I can escape looking like "+
					"this. I have to blend in or else.. things may not farewell for me if I get caught.\n\n"+
					"[Press S to head up Stairs, F to go to Floor, or C to head to the Closet Door] ";
		
		if(Input.GetKeyDown(KeyCode.S))		{if (x == UnityEngine.Random.Range (1,4)){myState = States.caught;}
											else {myState = States.stairs_0;}}
		else if(Input.GetKeyDown(KeyCode.F))	{myState = States.floor;}
		else if(Input.GetKeyDown(KeyCode.C))	{myState = States.closet_door;}
	
	}
	void state_caught () {
		text.text = "\"*Note to self: If your reading this you have been caught. Don't give up "+
					"no matter what you must escape again. But the choice is up to you*\" \n\n"+
					"[Press Spacebar to restart or G to Terminate game]";
		
		if(Input.GetKeyDown(KeyCode.Space)) {myState = States.cell;}
		//else if(Input.GetKeyDown(KeyCode.G)) System.Environment.Exit(0);
	} 
	void state_stairs_0 () {
		text.text = "Nope terrrible place to be, gonna get caught!!! \n\n"+
					"[Press R to Return]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_0;}
	}
	void state_closet_door () {
		text.text = "Darn it I can't get in, need keys. \n\n"+
					"[Press R to Return]";
		if(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_0;}		
	}
	void state_floor () {
		text.text = "Ok, keys, keys, keys. Where are they... *Notices hairclip* what's "+
					"this? A hairclip . *Sudden flash of memory* I dropped this here; as I was "+
					"carryed away I dropped it but why...? I can't think of that now, I need to think " +
					"of a plan asap. *Looks at hairclip* I know what to do.\n\n"+
					"[Press H to Pick up Hairclip, N to leave Hairclip on floor]";
		 if(Input.GetKeyDown(KeyCode.H)) 	{myState = States.corrider_1;}
		 else if(Input.GetKeyDown(KeyCode.N))	{myState = States.corridor_1_N;}
	}
	void state_corridor_1_N () {
		text.text = "I think I hear something. Let me head to the corridor quickly... Ok, I'm here. "+
					"*see's closet* there's a closet good I hope it's open. *Turns knob realizes it's locked* "+
					"DANG IT!!! what do I do?\n\n"+
					"[Press R to return to Floor or S to head to Stairway]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.caught;}
		else if(Input.GetKeyDown(KeyCode.S)) {if (x == UnityEngine.Random.Range (1,2)){myState = States.caught;}
			else {myState = States.stairs_1;}}
	}
	void state_corridor_1 () {
		text.text = "I think I hear something. Let me head to the corridor quickly... Ok, I'm here. "+
					"*see's closet* there's a closet good, maybe I can pick it with this hairclip "+
					"*hears footsteps* but I hear someone coming; should I pick it or hide in the stairway?\n\n"+
					"[Press P to Pick lock or S to head to stairway]";
		if(Input.GetKeyDown(KeyCode.P))	 	{myState = States.in_closet;}
		else if(Input.GetKeyDown(KeyCode.S)) {if (x == UnityEngine.Random.Range (1,3)){myState = States.caught;}
											else {myState = States.stairs_1;}}
	}
	void state_stairs_1 (){
		text.text = "*Hears talking* Crap gaurds are here to I need to leave. \n\n"+
					"[Press R to return]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.caught;}			
	}
	void state_in_closet (){
		text.text = "Yes, I'm in! Excellent, there are also gaurd uniforms here, I'm pretty darn lucky... \n\n"+
					"[Press D to Dress and head to the third corridor or R to head to the second corridor]";
		if(Input.GetKeyDown(KeyCode.D))		{myState = States.corridor_3;}
		else if(Input.GetKeyDown (KeyCode.R)) 	{myState = States.corridor_2;}
	} 
	void state_corridor_2 (){
		text.text = "Why did I come here? I'm wasting time. *Sounds of gaurd approching*\n\n "+
					"[Press B to head Back to closet or S to head to stairway 2]";
		if(Input.GetKeyDown(KeyCode.B))	 {if (x == UnityEngine.Random.Range (1,5)){myState = States.caught;} 
		 {myState = States.in_closet;}}
		else if(Input.GetKeyDown(KeyCode.S)) {if (x == UnityEngine.Random.Range (1,2)){myState = States.caught;}
			else {myState = States.stairs_2;}}
	}
	void state_corridor_3 () {
		text.text = "Yes I'm here, I just need to take the stairs to courtyard. \n\n" +
					"[Press S to take stairs to courtyard or U to head back to closet to Undress from disguise]";
		if(Input.GetKeyDown(KeyCode.S)) 	 {if (x == UnityEngine.Random.Range (1,2)){myState = States.caught;}
			else {myState = States.courtyard;}}
		else if(Input.GetKeyDown(KeyCode.U)) 	{myState = States.caught;}
	}
	void state_stairs_2 (){
		text.text = "*Hears footsteps approching* Darn it, none of the stairways are safe! "+
					"[Press of R to Return]";
		if(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_2;}	
	}
	void state_courtyard () {
		text.text = "Great the gate is open. *Truck is pulling in with new inmates* "+
					"this is my time I can escape with a vehicle through all the confusion.\n\n"+
					"[Press F for Freedom]";
		if(Input.GetKeyDown(KeyCode.F)) 	{myState = States.free;}
	}
	void state_free (){
		text.text = "I'm free!!!\n\n"+
					"[Press P to Play again]";
		if(Input.GetKeyDown(KeyCode.P)) 	{myState = States.cell;} 
	}
}

