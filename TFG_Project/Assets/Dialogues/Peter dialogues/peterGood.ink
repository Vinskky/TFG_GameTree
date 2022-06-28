-> main

== main ==
Are you done with your work dad? #speaker:Ava #portrait:ava #layout:left

I'll be done in 10 minutes, why? #speaker:Peter #portrait:peter #layout:right

I'm worried about mom, she seems really angry. #speaker:Ava #portrait:ava #layout:left

That's why I asked you for backup  #speaker:Peter #portrait:peter #layout:right
    + [I'm always here for the family]
        -> goodTake
    + [Okay... let's think]
        -> goodTake
        

== goodTake ==
You are a good daughter, do you know that right?

I've got an Idea... what if you take her to a good place for dinner? #speaker:Ava #portrait:ava #layout:left

That's a great idea, can you call for me to the restaurant while I'm finishing my work for the day? #speaker:Peter #portrait:peter #layout:right
    + [Sure dad]
        -> goodTakeEnd
    + [I'm on it!]
        -> goodTakeEnd
        
== goodTakeEnd ==
Thanks sweetheart, you're the best, and take this money for your night!
-> DONE

->END