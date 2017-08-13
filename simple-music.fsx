#r "FSharp.Powerpack.dll"
type Octave = int
type Dur = BigRational
type PitchClass = Cff | Cf | C | Dff | Cs | Df | Css | D | Eff | Ds
                | Ef | Fff | Dss | E | Ff | Es | F | Gff | Ess | Fs
                | Gf | Fss | G | Aff | Gs | Af | Gss | A | Bff | As
                | Bf | Ass | B | Bs | Bss

type Pitch = PitchClass * Octave

let a440: Pitch = (A, 4)
type Primitive<'a> = Note of Dur * 'a
                   | Rest of Dur

let bn: Dur = 2N
let wn: Dur = 1N
let hn: Dur = 1N/2N
let qn: Dur = 1N/4N
let en: Dur = 1N/8N
let sn: Dur = 1N/16N
let tn: Dur = 1N/32N
let sfn: Dur = 1N/64N
let dwn: Dur = 3N/2N
let dhn: Dur = 3N/4N
let dqn: Dur = 3N/8N
let den: Dur = 3N/16N
let dsn: Dur = 3N/32N
let dtn: Dur = 3N/64N
let ddhn: Dur = 7N/8N
let ddqn: Dur = 7N/16N
let dden: Dur = 7N/32N

let bnr = Rest bn
let wnr = Rest wn
let hnr = Rest hn
let qnr = Rest qn
let enr = Rest en
let snr = Rest sn
let tnr = Rest tn
let sfnr = Rest sfn
let dwnr = Rest dwn
let dhnr = Rest dhn
let dqnr = Rest dqn
let denr = Rest den
let dsnr = Rest dsn
let dtnr = Rest dtn
let ddhnr = Rest ddhn
let ddqnr = Rest ddqn
let ddenr = Rest dden

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

let cff (o: Octave) d = Prim(Note (d, ((Cff, o): Pitch)))
let cf (o: Octave) d = Prim(Note (d, ((Cf, o): Pitch)))
let c (o: Octave) d = Prim(Note (d, ((C, o): Pitch)))
let cs (o: Octave) d = Prim(Note (d, ((Cs, o): Pitch)))
let css (o: Octave) d = Prim(Note (d, ((Css, o): Pitch)))
let dff (o: Octave) d = Prim(Note (d, ((Dff, o): Pitch)))
let df (o: Octave) d = Prim(Note (d, ((Df, o): Pitch)))
let d (o: Octave) d = Prim(Note (d, ((D, o): Pitch)))
let ds (o: Octave) d = Prim(Note (d, ((Ds, o): Pitch)))
let dss (o: Octave) d = Prim(Note (d, ((Dss, o): Pitch)))
let eff (o: Octave) d = Prim(Note (d, ((Eff, o): Pitch)))
let ef (o: Octave) d = Prim(Note (d, ((Ef, o): Pitch)))
let e (o: Octave) d = Prim(Note (d, ((E, o): Pitch)))
let es (o: Octave) d = Prim(Note (d, ((Es, o): Pitch)))
let ess (o: Octave) d = Prim(Note (d, ((Ess, o): Pitch)))
let fff (o: Octave) d = Prim(Note (d, ((Fff, o): Pitch)))
let ff (o: Octave) d = Prim(Note (d, ((Ff, o): Pitch)))
let f (o: Octave) d = Prim(Note (d, ((F, o): Pitch)))
let fs (o: Octave) d = Prim(Note (d, ((Fs, o): Pitch)))
let fss (o: Octave) d = Prim(Note (d, ((Fss, o): Pitch)))
let gff (o: Octave) d = Prim(Note (d, ((Gff, o): Pitch)))
let gf (o: Octave) d = Prim(Note (d, ((Gf, o): Pitch)))
let g (o: Octave) d = Prim(Note (d, ((G, o): Pitch)))
let gs (o: Octave) d = Prim(Note (d, ((Gs, o): Pitch)))
let gss (o: Octave) d = Prim(Note (d, ((Gss, o): Pitch)))
let aff (o: Octave) d = Prim(Note (d, ((Aff, o): Pitch)))
let af (o: Octave) d = Prim(Note (d, ((Af, o): Pitch)))
let a (o: Octave) d = Prim(Note (d, ((A, o): Pitch)))
let as' (o: Octave) d = Prim(Note (d, ((As, o): Pitch)))
let ass (o: Octave) d = Prim(Note (d, ((Ass, o): Pitch)))
let bff (o: Octave) d = Prim(Note (d, ((Bff, o): Pitch)))
let bf (o: Octave) d = Prim(Note (d, ((Bf, o): Pitch)))
let b (o: Octave) d = Prim(Note (d, ((B, o): Pitch)))
let bs (o: Octave) d = Prim(Note (d, ((Bs, o): Pitch)))
let bss (o: Octave) d = Prim(Note (d, ((Bss, o): Pitch)))

let t251 =
  let dMinor = Par(Par(d 4 wn, f 4 wn), a 4 wn)
  let gMajor = Par(Par(g 4 wn, b 4 wn), d 5 wn)
  let cMajor = Par(Par(c 4 bn, e 4 bn), g 4 bn)
  Seq(Seq(dMinor, gMajor), cMajor)

let triple ((p, o): Pitch) =
  match p with
  | C -> (c o, e o, g o)
  | D -> (d o, f o, a o)
  | E -> (e o, g o, b o)
  | F -> (f o, a o, c (o+1))
  | G -> (g o, b o, d (o+1))
  | A -> (a o, c (o+1), e (o+1))
  | B -> (b o, d (o+1), f(o+1))
  | _ -> (c o, e o, g o)
let second ((p, o): Pitch) =
  match p with
  | C -> triple (D, o)
  | D -> triple (E, o)
  | E -> triple (F, o)
  | F -> triple (G, o)
  | G -> triple (A, o)
  | A -> triple (B, o)
  | B -> triple (C, (o+1))
  | _ -> triple (C, (o+1))
let fifth ((p, o): Pitch) =
  match p with
  | C -> triple (G, o)
  | D -> triple (A, o)
  | E -> triple (B, o)
  | F -> triple (C, (o+1))
  | G -> triple (D, (o+1))
  | A -> triple (E, (o+1))
  | B -> triple (F, (o+1))
  | _ -> triple (F, (o+1))
let first ((p, o): Pitch) =
  match p with
  | C -> triple (C, o)
  | D -> triple (D, o)
  | E -> triple (E, o)
  | F -> triple (F, o)
  | G -> triple (G, o)
  | A -> triple (A, o)
  | B -> triple (B, o)
  | _ -> triple (B, o)

let twoFiveOne (p: Pitch) (dur: Dur) =
  let (t1, t2, t3) = second p
  let (f1, f2, f3) = fifth p
  let (fr1, fr2, fr3) = first p
  let twoMinor = Par(Par(t1 dur, t2 dur), t3 dur)
  let fiveMajor = Par(Par(f1 dur, f2 dur), f3 dur)
  let oneMajor = Par(Par(fr1 dur, fr2 dur), fr3 dur)
  Seq(Seq( twoMinor, fiveMajor ), oneMajor)

let my251 = twoFiveOne (C, 4) wn