-> main

== main ==
Hi mom, I'm feeling better, the pills helped me a lot. #speaker:Ava #portrait:ava #layout:left

Oh I'm glad sweetheart. It's true that you look quite better #speaker:Sophia #portrait:sophia #layout:right

I'm thinking about the dinner. Do you want some Pizza?
    + [Pizza? On Tuesday?]
        -> goodTake
    + [Sounds good but...]
        -> badTake
        

== badTake ==

My friends called me and they want meet for dinner #speaker:Ava #portrait:ava #layout:left

Even if you look fine, you should stay at home #speaker:Sophia #portrait:sophia #layout:right

    + [C'mooon mom]
        -> badTakeEnd
    + [But today it's Anna's birthday]
        -> badTakeEnd

== badTakeEnd ==   
I don't care, it's better for your health to stay tonight
    + [It's not fair!]
        -> END
    + [I'll ask dad]
        -> END
        
== goodTake ==
I'm not in the mood to cook right now...
    + [Do you need to talk?]
        -> goodTakeEnd
    + [But you cook so great!]
        -> goodTakeEnd
        
== goodTakeEnd ==
Well... I've seen better days
    + [Do you need to talk?]
        Okey then...
        -> DONE
    + [Should I ask dad?]
        Okey then...
        -> DONE

->END