-> main

== main ==
Hi mom, I'm feeling better, the pills helped me a lot. #speaker:Ava #portrait:ava #layout:left

Oh I'm glad sweetheart. It's true that you look quite better #speaker:Sophia #portrait:sophia #layout:right

I'm thinking about the dinner. Do you want some Pizza?
    + [Pizza? On Tuesday?] #as_points:10
        -> goodTake
    + [Sounds good but...] #as_points:-10
        -> badTake
        

== badTake ==

My friends called me and they want meet for dinner #speaker:Ava #portrait:ava #layout:left

Even if you look fine, you should stay at home #speaker:Sophia #portrait:sophia #layout:right

    + [C'mooon mom] #as_points:-10
        -> badTakeEnd
    + [But today it's Anna's birthday] #as_points:-10
        -> badTakeEnd

== badTakeEnd ==   
I don't care, it's better for your health to stay tonight
    + [It's not fair!] #as_points:-10
        -> END
    + [I'll ask dad] #as_points:-10
        -> END
        
== goodTake ==
I'm not in the mood to cook right now...
    + [Do you need to talk?] #as_points:10
        -> goodTakeEnd
    + [But you cook so great!] #as_points:10
        -> goodTakeEnd
        
== goodTakeEnd ==
Well... I've seen better days
    + [Do you need to talk?] #as_points:10
        Okey then...
        -> DONE
    + [Should I ask dad?] #as_points:10
        Okey then...
        -> DONE

->END