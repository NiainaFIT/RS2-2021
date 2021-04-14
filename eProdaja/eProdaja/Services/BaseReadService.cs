﻿using AutoMapper;
using eProdaja.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    //BaseReadService koji zavisi od T(predstavlja objekat koji vraćam) nasljeđuje IReadService
    //TDb predstavlja objekat iz baze
    public class BaseReadService<T,TDb, TSearch> :IReadService<T, TSearch> where T:class where TDb:class where TSearch:class
    {
        public eProdajaContext Context { get; set; }
        protected readonly IMapper _mapper;
        public BaseReadService(eProdajaContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>();
            var list = entity.ToList();
            //mapiranje liste iz baze u listu objekata koje vraćam
            return _mapper.Map<List<T>>(list);
        }
        public virtual T GetById(int id)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);
            return _mapper.Map<T>(entity);
        }
    }
}