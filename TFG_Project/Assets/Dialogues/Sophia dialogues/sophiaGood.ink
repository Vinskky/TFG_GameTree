-> main

== main ==
Are you feeling better mom?

Well... discussions always make me angry.

    + [discussions...?]
        -> badTake
    + [It's okay mom]
        -> goodTake   

== badTake ==
You know your father, yesterday was our aniversary and he forgot about it!
        
Special days are not in his schedule, only meetings...

    - [That's unforgetable!]
        -> badTakeEnd
    - [Daddy is really busy]
        -> badTakeEnd

== badTakeEnd ==   
I know and I deserve to be mad!

Yes, but we can't stay mad forever... at some point we must forgive eachother's mistakes.

You are absolutely right sweetheart... I love you!
->DONE
        
== goodTake ==
I'm not in the mood to cook right now...
    + [Do you need to talk?]
        -> goodTakeEnd
    + [But you cook so great!]
        -> goodTakeEnd
        
== goodTakeEnd ==
What do you mean... "It's okay"

I meant that it's not a big deal...

    + [Dad loves you]
        -> endingScene
    + [There's plenty time to celebrate]
        -> endingScene
        
== endingScene ==
But the point here is that he forgot about it.
I feel stupid if I forgive him.

    + [Here nobody judges you.]
        -> DONE
    + [You're not stupid]
        -> DONE

->END