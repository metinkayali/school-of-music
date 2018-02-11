import { Music, Tempo, Dur, Pitch, Transpose, AbsPitch, SequentialMusic, ParallelMusic, Octave } from './music';

export function rest<A>(dur: Dur): Music<A> {
  return { primitive: { dur } };
}

export function note<A>(dur: Dur, pitch: Pitch): Music<A> {
  return { primitive: { dur, pitch } };
}

export function seq<A>(first: Music<A>, second: Music<A>): Music<A> {
  const r: SequentialMusic<A> = {
    first,
    second,
  };
  return r;
}

export function par<A>(first: Music<A>, second: Music<A>): Music<A> {
  const r: ParallelMusic<A> = {
    first,
    second,
  };
  return r;
}

export function tempo<A>(rational: number, music: Music<A>): Music<A> {
  return { control: { rational }, music };
}

export function transpose<A>(absPitch: AbsPitch, music: Music<A>): Music<A> {
  return { control: { absPitch }, music };
}

export function instrument<A>(instrumentName: string, music: Music<A>): Music<A> {
  return { control: { instrumentName }, music };
}

export function player<A>(playerName: string, music: Music<A>): Music<A> {
  return { control: { playerName }, music };
}

export function keySig<A>(pitchClass: 'Major' | 'Minor', music: Music<A>): Music<A> {
  return { control: { pitchClass }, music };
}

export const qn: Dur = 1;
export const wn: Dur = 4;
export const bn: Dur = 2;

const dMin = par(
  par (
    note(wn, { octave: 4, pitchClass: 'D' }),
    note(wn, { octave: 4, pitchClass: 'F' })),
    note(wn, { octave: 4, pitchClass: 'A' })
);
const gMaj = par(
  par (
    note(wn, { octave: 4, pitchClass: 'G' }),
    note(wn, { octave: 4, pitchClass: 'B' })),
    note(wn, { octave: 5, pitchClass: 'D' })
);
const cMaj = par(
  par (
    note(bn, { octave: 4, pitchClass: 'C' }),
    note(bn, { octave: 4, pitchClass: 'E' })),
    note(bn, { octave: 4, pitchClass: 'G' })
);

export const t251 = seq (
  seq ( dMin,
        gMaj ),
        cMaj
);