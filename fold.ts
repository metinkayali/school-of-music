import {
  Music, Pitch,
} from './types';
import {
  rest, seq, par,
} from './constructors/music';
import { absPitch, pitch } from './absolute-pitch';

type Fn = <T>(acc: Music<T>, m: Music<T>) => Music<T>;

const apply = (fn:Fn) => <T>(ms: Music<T>[]) =>
  ms.reduce(
    fn,
    rest<T>(0)
  );

export const line = apply(seq);
export const chord = apply(par);

export const maxPitch = (ps: Pitch[]): Pitch =>
  ps.reduce(
    (acc, p) => absPitch(acc) > absPitch(p) ? acc : p,
    pitch(0),
  );