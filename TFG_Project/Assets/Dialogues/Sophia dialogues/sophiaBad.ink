-> main

== main ==
It's smell like alcohol? Have you been driking? #speaker:Ava #portrait:ava #layout:left

It doesn't matter, leave me alone #speaker:Sophia #portrait:sophia #layout:right

    + [You need to talk to someone]
        -> goodTake
    + [I'm worried]
        -> badTake
        

== badTake ==

I know but I can't handle this situation any longer. 

    + [It's okay I'm here with you.]
        -> badTakeEnd
    + [What are you saying...]
        -> badTakeEnd

== badTakeEnd ==   
Ava I want to leave this house...

Don't you dare to leave me here alone... #speaker:Ava #portrait:ava #layout:left

So... are you comming with me? #speaker:Sophia #portrait:sophia #layout:right

    + [I can't... this is too much]
        -> END
    + [Obviously mom]
        -> END
        
== goodTake ==
I'm not asking for your help.

Well, I don't care because it's awful. #speaker:Ava #portrait:ava #layout:left

I do whatever I want! I'm a grown up woman and you can't say nothing #speaker:Sophia #portrait:sophia #layout:right
    + [Ofcourse I can talk!!]
        -> goodTakeEnd
    + [You're very irresponsable]
        -> goodTakeEnd
        
== goodTakeEnd ==
Oh yeah? I'm unconfortable in this house. I can't handle it anymore #speaker:Sophia #portrait:sophia #layout:right

Have fun with your dad... if he can remember that has a daughter...


->END