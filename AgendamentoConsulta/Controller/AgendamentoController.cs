using Model;
using System.Linq;
using System.Data;
using System;

namespace Controller
{
    public class AgendamentoController
    {
        public bool IncluirAgendamento(Agendamento agendamento)
        {
            if (ValidaHorarioAtendimento())
            {

            }

            ContextoSingleton.Instancia.Agendamentos.Add(agendamento);
            ContextoSingleton.Instancia.SaveChanges();
            return true;
        }

        public void ExcluirAgendamento(int idAgendamento)
        {
            Agendamento a = ContextoSingleton.Instancia.Agendamentos.Find(idAgendamento);

            ContextoSingleton.Instancia.Entry(a).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public Agendamento ListarAgendamentoPorDia(DataSetDateTime dia)
        {
            var pr = from x in ContextoSingleton.Instancia.Agendamentos
                     where x.DataHoraConsulta.Equals(dia)
                     select x;

            if (pr != null)
                return pr.FirstOrDefault();
            else
                return null;
        }




        public Agendamento PesquisarAgendamentoPorId(int idAgendamento)
        {
            var a = from x in ContextoSingleton.Instancia.Agendamentos
                    where x.AgendamentoID.Equals(idAgendamento)
                    select x;
            if (a != null)
                return a.FirstOrDefault();
            else
                return null;
        }

        public void EditarAgendamento(int idAgendamento, Agendamento novoAgendamento)
        {

        }





        public bool ValidaHorarioAtendimento(Agendamento agendamento)
        {
            //Validando horário em que o profissional atende e o horário que o local está aberto para atendimento (não valida dia da semana e horário com consulta já marcada)
            if (agendamento.DataHoraConsulta.TimeOfDay < agendamento._Profissional.HrInicio.TimeOfDay ||
                agendamento.DataHoraConsulta.AddMinutes(agendamento.TempoEmMinutosConsulta).TimeOfDay > agendamento._Profissional.HrFim.TimeOfDay)
                return false;
            else
            {
                if (agendamento.DataHoraConsulta.TimeOfDay < agendamento._Local.HrInicio.TimeOfDay ||
                agendamento.DataHoraConsulta.AddMinutes(agendamento.TempoEmMinutosConsulta).TimeOfDay > agendamento._Local.HrFim.TimeOfDay)
                    return false;
            }
            return true;
        }

        public bool ValidaDiaDaSemanaAtendimento(Agendamento agendamento)
        {
            //dia da semana em formato ddd para comparação (dom, seg, ter, qua, qui, sex, sab)
            //Validando dia da semana disponível para profissional e local
            String diaDaSemana = agendamento.DataHoraConsulta.ToString("ddd");
            if (diaDaSemana.Equals("dom"))
            {
                if (!agendamento._Profissional.Domingo || !agendamento._Local.Domingo)
                    return false;
            }
            else
            {
                if (diaDaSemana.Equals("seg"))
                {
                    if (!agendamento._Profissional.Segunda || !agendamento._Local.Segunda)
                        return false;
                }
                else
                {
                    if (diaDaSemana.Equals("ter"))
                    {
                        if (!agendamento._Profissional.Terca || !agendamento._Local.Terca)
                            return false;
                    }
                    else
                    {
                        if (diaDaSemana.Equals("qua"))
                        {
                            if (!agendamento._Profissional.Quarta || !agendamento._Local.Quarta)
                                return false;
                        }
                        else
                        {
                            if (diaDaSemana.Equals("qui"))
                            {
                                if (!agendamento._Profissional.Quinta || !agendamento._Local.Quinta)
                                    return false;
                            }
                            else
                            {
                                if (diaDaSemana.Equals("sex"))
                                {
                                    if (!agendamento._Profissional.Sexta || !agendamento._Local.Sexta)
                                        return false;
                                }
                                else
                                {
                                    if (diaDaSemana.Equals("sab"))
                                    {
                                        if (!agendamento._Profissional.Sabado || !agendamento._Local.Sabado)
                                            return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool ValidaHorarioLivreProfissional(Agendamento agendamento)
        {
            DateTime inicioConsulta = agendamento.DataHoraConsulta;
            DateTime terminoConsulta = agendamento.DataHoraConsulta.AddMinutes(agendamento.TempoEmMinutosConsulta);

            var a = from x in ContextoSingleton.Instancia.Agendamentos
                    where x._Profissional.Equals(agendamento._Profissional) &&
                    (x.DataHoraConsulta >= inicioConsulta && x.DataHoraConsulta < terminoConsulta) ||
                    (x.DataHoraConsulta.AddMinutes(x.TempoEmMinutosConsulta) > inicioConsulta && x.DataHoraConsulta.AddMinutes(x.TempoEmMinutosConsulta) <= terminoConsulta)
                    select x;

            if (a != null)
                return false;
            else
                return true;
        }

        public bool ValidaHorarioLivreLocal(Agendamento agendamento)
        {
            DateTime inicioConsulta = agendamento.DataHoraConsulta;
            DateTime terminoConsulta = agendamento.DataHoraConsulta.AddMinutes(agendamento.TempoEmMinutosConsulta);

            var a = from x in ContextoSingleton.Instancia.Agendamentos
                    where x._Local.Equals(agendamento._Local) &&
                    (x.DataHoraConsulta >= inicioConsulta && x.DataHoraConsulta < terminoConsulta) ||
                    (x.DataHoraConsulta.AddMinutes(x.TempoEmMinutosConsulta) > inicioConsulta && x.DataHoraConsulta.AddMinutes(x.TempoEmMinutosConsulta) <= terminoConsulta)
                    select x;

            if (a != null)
                return false;
            else
                return true;
        }

    }
}
