export type Octave = number;
export type Dur = number;
export type PitchClass =
  'Cff' | 'Cf' | 'C' | 'Dff' | 'Cs' | 'Df' | 'Css' | 'D' | 'Eff' | 'Ds' |
  'Ef' | 'Fff' | 'Dss' | 'E' | 'Ff' | 'Es' | 'F' | 'Gff' | 'Ess' | 'Fs' |
  'Gf' | 'Fss' | 'G' | 'Aff' | 'Gs' | 'Af' | 'Gss' | 'A' | 'Bff' | 'As' |
  'Bf' | 'Ass' | 'B' | 'Bs' | 'Bss';

export type Pitch = {
  pitchClass: PitchClass;
  octave: Octave;
}

export type Note<T> = {
  dur: Dur;
  pitch: T;
}

export type AbsPitch = number;

export type Rest = {
  dur: Dur;
}

export type Tempo = {
  rational: number;
}

export type Transpose = {
  absPitch: AbsPitch;
}

export type Instrument = {
  instrumentName: string;
}

export type Player = {
  playerName: string;
}

export type KeySig = {
  pitchClass: 'Major' | 'Minor';
}

export type Control =
  | Tempo
  | Transpose
  | Instrument
  | Player
  | KeySig;

export type Primitive<T> =
  | Note<T>
  | Rest;

export type Music<T> =
  | Prim<T>
  | SequentialMusic<T>
  | ParallelMusic<T>
  | ModifiedMusic<T>;

export type Prim<T> = {
  primitive: Primitive<T>;
};
export interface SequentialMusic<T> {
  first: Music<T>;
  second: Music<T>;
}
export interface ParallelMusic<T> {
  first: Music<T>;
  second: Music<T>;
}
export interface ModifiedMusic<T> {
  music: Music<T>;
  control: Control;
}