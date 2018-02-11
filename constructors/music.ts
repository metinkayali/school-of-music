import {
  Music,
  Tempo, Dur, Pitch, Transpose, AbsPitch, SequentialMusic, ParallelMusic, Octave
} from '../types';

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

export const wnr = <A>(): Music<A> => rest(wn);
export const bnr = <A>(): Music<A> => rest(bn);
export const qnr = <A>(): Music<A> => rest(qn);