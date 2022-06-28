-> main

== main ==
Hey honey! You look much better #speaker:Peter #portrait:peter #layout:right

Yeah the pills you bought me were great! #speaker:Ava #portrait:ava #layout:left

I'm glad you feel better... Do you know what we have for dinner? #speaker:Peter #portrait:peter #layout:right
    + [Don't know, but will be good for sure]
        -> goodTake
    + [Don't know... ask mom]
        -> badTake
        

== badTake ==

I think I can't do that, at least for now...

    + [Why not? ]
        -> badTakeEnd
    + [What have you done?]
        -> badTakeEnd

== badTakeEnd ==   
Your mom is having a bad day... And today I'm the victim
I just forgot one tiny date...
    + [Oh no...]
    C'mon... don't bother me anymore, I must attend something important
        -> DONE
    + [Like usual...]
    C'mon... don't bother me anymore, I must attend something important
        -> DONE
        
== goodTake ==
Yeah that's for sure, your mom always make splendid meals.
I must ask for your help honey... I messed up...
    + [What happened?]
        -> goodTakeEnd
    + [What did you do this time?]
        -> goodTakeEnd
        
== goodTakeEnd ==
Yesterday I had a long meeting with a Chinesse collegue

And forgot our aniversary... Could you help your dad?

Only if I can go to dinner with my friends tonight. #speaker:Ava #portrait:ava #layout:left

If you can calm your mom, we have a deal! #speaker:Peter #portrait:peter #layout:right
    + [I'm on it!]
        -> DONE
    + [Sure, no problem!]
        -> DONE

->END