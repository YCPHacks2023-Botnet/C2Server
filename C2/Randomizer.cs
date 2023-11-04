﻿using System;

namespace C2;

public static class Randomizer
{
    public static Random Random = new Random();

    public static readonly List<string> Adverbs = new()
    {
        "fully",
        "joyously",
        "upliftingly",
        "evenly",
        "joyfully",
        "nervously",
        "warmly",
        "truly",
        "optimistically",
        "effectively",
        "safely",
        "worriedly",
        "bitterly",
        "inquisitively",
        "bleakly",
        "currently",
        "significantly",
        "regularly",
        "cleverly",
        "devotedly",
        "yearningly",
        "punctually",
        "rigidly",
        "selfishly",
        "patiently",
        "voluntarily",
        "meaningfully",
        "daily",
        "wrongly",
        "absentmindedly",
        "tightly",
        "adventurously",
        "tenderly",
        "wetly",
        "mysteriously",
        "speedily",
        "intently",
        "broadly",
        "coaxingly",
        "often",
        "cheerfully",
        "hourly",
        "gleefully",
        "upward",
        "relatively",
        "then",
        "boldly",
        "dearly",
        "violently",
        "yieldingly",
        "ahead",
        "dutifully",
        "cautiously",
        "deeply",
        "anyway",
        "partially",
        "honestly",
        "coyly",
        "diligently",
        "busily",
        "nearly",
        "needily",
        "weakly",
        "less",
        "extremely",
        "completely",
        "yearly",
        "seldom",
        "awkwardly",
        "youthfully",
        "widely",
        "fast",
        "faithfully",
        "briskly",
        "surprisingly",
        "daintily",
        "previously",
        "ferociously",
        "properly",
        "frankly",
        "wholly",
        "annually",
        "literally",
        "certainly",
        "strongly",
        "vivaciously",
        "specifically",
        "nicely",
        "forth",
        "lightly",
        "ultimately",
        "vastly",
        "similarly",
        "roughly",
        "tomorrow",
        "physically",
        "acidly",
        "rarely",
        "wonderfully",
        "seriously"
    };

    public static readonly List<string> Adjectives = new()
    {
        "new",
        "hurried",
        "premium",
        "roomy",
        "unused",
        "frail",
        "quizzical",
        "tasteless",
        "judicious",
        "offbeat",
        "terrible",
        "crooked",
        "stale",
        "steadfast",
        "nine",
        "rainy",
        "living",
        "obsolete",
        "illegal",
        "like",
        "organic",
        "brief",
        "smoggy",
        "economic",
        "second",
        "fantastic",
        "gleaming",
        "trashy",
        "adaptable",
        "fumbling",
        "familiar",
        "reflective",
        "outgoing",
        "flimsy",
        "savory",
        "slim",
        "faint",
        "juvenile",
        "elastic",
        "waggish",
        "elderly",
        "abortive",
        "striped",
        "resonant",
        "heavy",
        "tacit",
        "alive",
        "scattered",
        "simple",
        "rustic",
        "fanatical",
        "loutish",
        "nutty",
        "abiding",
        "heavenly",
        "melted",
        "glorious",
        "screeching",
        "coordinated",
        "scary",
        "futuristic",
        "spiritual",
        "ready",
        "lavish",
        "energetic",
        "bitter",
        "dynamic",
        "watery",
        "hateful",
        "obese",
        "grotesque",
        "mixed",
        "defiant",
        "uninterested",
        "helpless",
        "gorgeous",
        "abhorrent",
        "abrupt",
        "rotten",
        "whole",
        "chief",
        "classy",
        "incompetent",
        "bashful",
        "fine",
        "historical",
        "disturbed",
        "subdued",
        "squeamish",
        "rude",
        "used",
        "anxious",
        "abundant",
        "arrogant",
        "level",
        "unusual",
        "tested",
        "broken",
        "jaded",
        "ignorant"
    };

    public static readonly List<string> Nouns = new()
    {
        "receipt",
        "pets",
        "yarn",
        "thunder",
        "bedroom",
        "coach",
        "zoo",
        "elbow",
        "tomatoes",
        "bulb",
        "pocket",
        "view",
        "tendency",
        "advice",
        "fog",
        "unit",
        "instrument",
        "committee",
        "plastic",
        "boy",
        "chickens",
        "smell",
        "plane",
        "hose",
        "hate",
        "interest",
        "route",
        "chalk",
        "stove",
        "turkey",
        "oatmeal",
        "daughter",
        "kitty",
        "truck",
        "authority",
        "mask",
        "earth",
        "secretary",
        "haircut",
        "business",
        "rifle",
        "shelf",
        "tree",
        "fruit",
        "brass",
        "achiever",
        "word",
        "brake",
        "library",
        "sugar",
        "death",
        "leather",
        "station",
        "song",
        "giraffe",
        "front",
        "color",
        "cover",
        "root",
        "wave",
        "end",
        "orange",
        "slope",
        "cherry",
        "insect",
        "pleasure",
        "lip",
        "metal",
        "ants",
        "suit",
        "things",
        "morning",
        "cough",
        "design",
        "night",
        "connection",
        "sand",
        "queen",
        "debt",
        "insurance",
        "request",
        "pest",
        "ice",
        "agreement",
        "loss",
        "earthquake",
        "name",
        "twig",
        "card",
        "thing",
        "picture",
        "kiss",
        "floor",
        "stem",
        "son",
        "spy",
        "squirrel",
        "statement",
        "fold",
        "nation"
    };

    public static string GenerateName()
    {
        string adverb = Adverbs[Random.Next(Adverbs.Count)];
        string adjective = Adjectives[Random.Next(Adjectives.Count)];
        string noun = Nouns[Random.Next(Nouns.Count)];

        return $"{adverb}-{adjective}-{noun}";
    }

    public static int GenerateInt()
    {
        return Random.Next();
    }
}