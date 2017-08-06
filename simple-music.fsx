#r "FSharp.Powerpack.dll"
type Octave = int
type Dur = BigRational

let wn: Octave = 1
let bn: Octave = 2
let qn: Dur = 1N / 4N // quarter note
type PitchClass = Cff | Cf | C | Dff | Cs | Df | Css | D | Eff | Ds
                | Ef | Fff | Dss | E | Ff | Es | F | Gff | Ess | Fs
                | Gf | Fss | G | Aff | Gs | Af | Gss | A | Bff | As
                | Bf | Ass | B | Bs | Bss

type Pitch = PitchClass * Octave

let a440: Pitch = (A, 4)
type Primitive<'a> = Note of Dur * 'a
                   | Rest of Dur

type PlayerName = string
type Mode = Major | Minor
type AbsPitch = int
type PhraseAttribute = char
type InstrumentName =
  | AcousticGrandPiano | BrightAcousticPiano | ElectricGrandPiano
  | HonkyTonkPiano | RhodesPiano | ChorusedPiano
  | Harpsichord | Clavinet | Celesta
  | Glockenspiel | MusicBox | Vibraphone
  | Marimba | Xylophone | TubularBells
  | Dulcimer | HammondOrgan | PercussiveOrgan
  | RockOrgan | ChurchOrgan | ReedOrgan
  | Accordion | Harmonica | TangoAccordion
  | AcousticGuitarNylon | AcousticGuitarSteel | ElectricGuitarJazz
  | ElectricGuitarClean | ElectricGuitarMuted | OverdrivenGuitar
  | DistortionGuitar | GuitarHarmonics | AcousticBass
  | ElectricBassFingered | ElectricBassPicked | FretlessBass
  | SlapBass1 | SlapBass2 | SynthBass1
  | SynthBass2 | Violin | Viola
  | Cello | Contrabass | TremoloStrings
  | PizzicatoStrings | OrchestralHarp | Timpani
  | StringEnsemble1 | StringEnsemble2 | SynthStrings1
  | SynthStrings2 | ChoirAahs | VoiceOohs
  | SynthVoice | OrchestraHit | Trumpet
  | Trombone | Tuba | MutedTrumpet
  | FrenchHorn | BrassSection | SynthBrass1
  | SynthBrass2 | SopranoSax | AltoSax
  | TenorSax | BaritoneSax | Oboe
  | Bassoon | EnglishHorn | Clarinet
  | Piccolo | Flute | Recorder
  | PanFlute | BlownBottle | Shakuhachi
  | Whistle | Ocarina | Lead1Square
  | Lead2Sawtooth | Lead3Calliope | Lead4Chiff
  | Lead5Charang | Lead6Voice | Lead7Fifths
  | Lead8BassLead | Pad1NewAge | Pad2Warm
  | Pad3Polysynth | Pad4Choir | Pad5Bowed
  | Pad6Metallic | Pad7Halo | Pad8Sweep
  | FX1Train | FX2Soundtrack | FX3Crystal
  | FX4Atmosphere | FX5Brightness | FX6Goblins
  | FX7Echoes | FX8SciFi | Sitar
  | Banjo | Shamisen | Koto
  | Kalimba | Bagpipe | Fiddle
  | Shanai | TinkleBell | Agogo
  | SteelDrums | Woodblock | TaikoDrum
  | MelodicDrum | SynthDrum | ReverseCymbal
  | GuitarFretNoise | BreathNoise | Seashore
  | BirdTweet | TelephoneRing | Helicopter
  | Applause | Gunshot | Percussion
  | Custom of string

type Control = 
  | Tempo of BigRational
  | Transpose of AbsPitch
  | Instrument of InstrumentName
  | Player of PlayerName
  | Phrase of PhraseAttribute list
  | KeySig of PitchClass * Mode
type Music<'a> = 
  | Prim of Primitive<'a>
  | Seq of Music<'a> * Music<'a>
  | Par of Music<'a> * Music<'a>
  | Modify of Control * Music<'a>

let a440m = Prim (Note (qn, a440))
let note d p = Prim (Note (d,p))
let rest d = Prim (Rest (d))
let tempo r m = Modify ((Tempo r), m)
let transpose i m = Modify((Transpose i), m)
let instrument i m = Modify((Instrument i), m)
let phrase pa m = Modify((Phrase pa), m)
let player p m = Modify((Player p), m)
let keysig pc mo m = Modify((KeySig (pc, mo)), m)

let c d (o: Octave) = Prim(Note (d, ((C, o): Pitch)))
let d d (o: Octave) = Prim(Note (d, ((D, o): Pitch)))
let e d (o: Octave) = Prim(Note (d, ((E, o): Pitch)))
let f d (o: Octave) = Prim(Note (d, ((F, o): Pitch)))
let g d (o: Octave) = Prim(Note (d, ((G, o): Pitch)))
let a d (o: Octave) = Prim(Note (d, ((A, o): Pitch)))
let b d (o: Octave) = Prim(Note (d, ((B, o): Pitch)))

let t251 =
  let dMinor = Par(Par(d 4N wn, f 4N wn), a 4N wn)
  let gMajor = Par(Par(g 4N wn, b 4N wn), d 5N wn)
  let cMajor = Par(Par(c 4N wn, e 4N wn), g 4N wn)
  Seq(Seq(dMinor, gMajor), cMajor)