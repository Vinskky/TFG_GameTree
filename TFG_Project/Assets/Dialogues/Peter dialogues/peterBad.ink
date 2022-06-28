-> main

== main ==
Ew dad, have you been smoking in here? #speaker:Ava #portrait:ava #layout:left

It's not of your bussiness young lady #speaker:Peter #portrait:peter #layout:right
    + [Well, I care for you]
        -> goodTake
    + [I'm gonna to tell mom]
        -> badTake
        

== badTake ==

Don't you dare Ava! She has her issues too

    + [What do you mean?]
        -> badTakeEnd
    + [I know that...]
        -> badTakeEnd

== badTakeEnd ==   
I don't think i can't do this anymore... I want to leave your mom sweetheart

What? And what about me? #speaker:Ava #portrait:ava #layout:left

You can come with me if you want #speaker:Peter #portrait:peter #layout:right
    + [I'll pack right now]
        Let's go! 
        -> DONE
    + [I won't leave mom alone. Bye!]
       Bye bye Ava...
        -> DONE
        
== goodTake ==
I just want to be alone now.
Oh! I just finish my last packet of cigarrets..

    + [Better]
        -> goodTakeEnd
    + [I hope is the last one]
        -> goodTakeEnd
        
== goodTakeEnd ==
You know kid? I don't think so... your mom gives me so anxiety
I'm going to buy some cigarrets okay? Don't wait for me...

buit everythoing is close now #speaker:Ava #portrait:ava #layout:left

I don't care, I'm just leaving your mom and this house of madness #speaker:Peter #portrait:peter #layout:right


->END